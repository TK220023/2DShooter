using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPController : MonoBehaviour
{
    public float MaxHp = 10;

    float HP;
    readonly float damage = 2;
    EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHp;
        enemyManager = GameObject.Find("GameManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage()
    {
        HP -= damage;

        if (HP <= 0)
        {
            enemyManager.killedEnemyCount++;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }
}