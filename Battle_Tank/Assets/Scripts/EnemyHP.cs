using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP;
    public int damage1;
    public int damage2;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            HP -= damage1;
            Status();
        }
        else if (collision.gameObject.CompareTag("Shell2"))
        {
            HP -= damage2;
            Status();
        }
    }

    void Status()
    {
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
}
