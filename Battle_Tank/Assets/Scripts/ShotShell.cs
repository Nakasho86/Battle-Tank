using UnityEngine;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //インプットシステム
        isa = new InputSystem_Actions();
        isa.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //インプットシステム
        //「shot」に定義されたボタンを押したとき(条件)
        if (isa.Player.Shot.triggered)
        {
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

    //インプットシステム
    private　void OnDisable()
    {
        isa.Disable();
    }
}
