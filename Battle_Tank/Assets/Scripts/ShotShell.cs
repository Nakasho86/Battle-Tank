using UnityEngine;
using TMPro;

public class ShotShell : MonoBehaviour
{
    //インプットシステム
    private InputSystem_Actions isa;

    public GameObject shellPrefab;
    public GameObject shellPrefab2;
    public AudioClip shotSound;
    public float shotSpeed;
    public GameObject shotPoint;
    private float shotPower;

    public int shellCount;
    public TextMeshProUGUI shellLabel;

    public int maxShell = 20;
    public AudioClip itemSound;
    //public GameObject effectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //インプットシステム
        isa = new InputSystem_Actions();
        isa.Enable();

        shellLabel.text = "" + shellCount;
    }

    // Update is called once per frame
    void Update()
    {
        //インプットシステム
        //「shot」に定義されたボタンを押したとき(条件)
        if (isa.Player.Shot.triggered)
        {
            if (shellCount < 1)
            {
                return;
            }

            shellCount -= 1;
            shellLabel.text = "" + shellCount;
            GameObject shell = Instantiate(shellPrefab, shotPoint.transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            Destroy(shell, 2.0f);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }

        //ボタンを押している間(条件)
        if (isa.Player.Shot2.IsPressed())
        {
            //パワーチャージ
            shotPower += 2;

            if (shotPower > 1000)
            {
                //パワー上限
                shotPower = 1000;
            }
        }

        //ボタンを離したとき(条件)
        if (isa.Player.Shot2.WasReleasedThisFrame())
        {
            GameObject shell = Instantiate(shellPrefab2, shotPoint.transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotPower);

            AudioSource.PlayClipAtPoint(shotSound,transform.position);
            Destroy(shell, 3.0f);

            //パワーリセット
            shotPower = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShellItem"))
        {
            //アイテムを消す
            Destroy(other.gameObject);

            //効果音を消す
            AudioSource.PlayClipAtPoint(itemSound, transform.position);

            //エフェクトを出す
            //GameObject effect = Instantiate(effectPrefab,other.transform.position,Quaternion.identity);

            //エフェクトを消す
            //Destroy(effect, 1.0f);

            //Shellを「５」回復させる
            shellCount += 5;
            shellLabel.text = "" + shellCount;

            //弾数が最大値を超えないように制限する
            if (shellCount > maxShell)
            {
                shellCount = maxShell;
                shellLabel.text = "" + shellCount;
            }
        }
    }

    //インプットシステム
    private　void OnDisable()
    {
        isa.Disable();
    }
}
