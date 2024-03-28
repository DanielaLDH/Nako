using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public EnemySpawner spawner;

    public int numEnemy;
    public int damEnemy;
    public int speEnemy;


    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            player.transform.position = point.transform.position;
           // spawner.numberOfEnemies += numEnemy;
            enemy.damage += damEnemy;
            enemy.speed += speEnemy;
        }
    }
}
