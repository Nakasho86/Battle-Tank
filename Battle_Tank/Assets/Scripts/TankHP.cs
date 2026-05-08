using UnityEngine;
using TMPro;

public class TankHP : MonoBehaviour
{
    public int HP;

    public TextMeshProUGUI HPLabel;

    public int maxHP = 8; //最大HP
    public AudioClip itemSound;
    public GameObject effectPrefab;

    void Start()
    {
        HPLabel.text = "" + HP; 
    }

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
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HPItem"))
        {
            //HPアイテムを消す
            Destroy(other.gameObject);

            //効果音を出す
            AudioSource.PlayClipAtPoint(itemSound,transform.position);

            //エフェクトを消す
            Destroy(effectPrefab, 1.0f);

            //HPを「２」回復させる
            HP += 2;
            HPLabel.text = "" + HP;

            //HPが最大値を超えないように制限する
            if (HP > maxHP)
            {
                HP = maxHP;
                HPLabel.text = "" + HP;
            }
        }
    }
}
