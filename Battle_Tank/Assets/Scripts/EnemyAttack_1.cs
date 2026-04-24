using UnityEngine;
using System.Collections;

public class EnemyAttack_1 : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public AudioClip shotSound;
    private SphereCollider sCollider;

    //敵の攻撃力
    //１、砲弾の速度
    public float shotSpeed;
    //２、1ターンの攻撃回数
    public int attackNum;
    //３、1ターンの攻撃間隔
    public float attackInterval;
    //４、探知能力
    public float serachArea;

    private void Start()
    {
        sCollider = GetComponent<SphereCollider>();

        //colliderの半径の設定
        sCollider.radius = serachArea;

        //Is Trigger オン
        sCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tank")
        {
            //親オブジェクトがターゲットの方に向く
            transform.root.LookAt(other.transform);

            StartCoroutine(Attack());
        }
    }

    //コルーチン
    private IEnumerator Attack()
    {
        for (int i = 0; i < attackNum; i++)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();
            enemyShellRb.useGravity = false;
            enemyShellRb.AddForce(transform.forward * shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);

            yield return new WaitForSeconds(attackInterval);
        }
    }
}
