using UnityEngine;

public class TankHP : MonoBehaviour
{
    public int HP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyShell"))
        {
            HP -= 1;

            if (HP < 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
