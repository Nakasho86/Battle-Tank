using UnityEngine;

public class TankMonvement : MonoBehaviour
{
    //インプットシステム
    private InputSystem_Actions isa;

    public float movespeed;
    public float turnspeed;
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
        Vector2 movement2 = isa.Player.Move.ReadValue<Vector2>();
        Vector3 movement3 = new Vector3(movement2.x, 0, movement2.y);

        //前進・後退
        transform.Translate(Vector3.forward * movement3.z * Time.deltaTime * movespeed);

        //旋回
        transform.Rotate(Vector3.up * movement3.x * Time.deltaTime * turnspeed);
    }

    //インプットシステム
    private void OnDisable()
    {
        isa.Disable();
    }
}
