using UnityEngine;
using TMPro;

public class TankHP : MonoBehaviour
{
    public int HP;

    public TextMeshProUGUI HPLabel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyShell"))
        {
            HP -= 1;

            HPLabel.text = "" + HP;

            if (HP < 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
