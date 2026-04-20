using UnityEngine;

public class DestroyShell : MonoBehaviour
{
    public GameObject effectPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //自分を破壊する
        Destroy(gameObject);

        //爆発のエフェクトを出す
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

        //エフェクトを消す
        Destroy(effect, 1f);
    }
}
