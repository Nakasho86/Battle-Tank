using UnityEngine;

public class ShotShell : MonoBehaviour
{
    //インプットシステム
    private InputSystem_Actions isa;

    public GameObject shellPrefab;
    public AudioClip shotSound;
    public float shotSpeed;
    public GameObject shotPoint;

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
    }

    //インプットシステム
    private　void OnDisable()
    {
        isa.Disable();
    }
}
