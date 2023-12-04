using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public float spawnRadius = 5f;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    
    }

    void SpawnEnemy()
    {
        if (numberOfEnemies > 0)
        {
            Vector2 randomSpawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);

            numberOfEnemies--;
        }
        else
        {
            // Cancela a repetição após todos os inimigos terem sido spawnados
            CancelInvoke("SpawnEnemy");
        }
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnEnemies : MonoBehaviour
//{

//    public List<GameObject> enemiesList = new List<GameObject>();

//    private float timeCount;
//    public float spawnTime;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        timeCount += Time.deltaTime;

//        if (timeCount >= spawnTime)
//        {
//            //instancia inimigo
//            SpawnEnemy();
//            timeCount = 0f;
//        }
//    }

//    void SpawnEnemy()
//    {
//        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(0f, 3f), 0), transform.rotation);
//    }

//}
