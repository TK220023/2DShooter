using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject[] enemyPrefabs;
    public int killedEnemyCount = 0;
    int currentNumuberOfEnemy = 0;
    int maxEnemy = 5;
    float instantiateCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), 0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(10, Random.Range(-10, 10)), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(-10, Random.Range(-10, 10)), Quaternion.identity);

        currentNumuberOfEnemy = 3;
        Invoke(nameof(InstantiateEnemy), 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateEnemy()
    {
        maxEnemy++;
        int rate = Random.Range(0, 10);
        int spawn = 0;
        if(rate >= 8)
        {
            spawn = 1;
        }

        if(currentNumuberOfEnemy < maxEnemy)
        {
            Instantiate(enemyPrefabs[spawn],new Vector3(Random.Range(-10,10), Random.Range(-10,10)), Quaternion.identity);
        }
        instantiateCount -= 0.1f;

        Invoke(nameof(InstantiateEnemy), instantiateCount);
        Debug.Log(instantiateCount);
    }
}
