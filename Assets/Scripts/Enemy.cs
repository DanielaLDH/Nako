using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public GameObject healthPickupPrefab;

    private Transform player;
    private NextLevel nextLevel;// Refer�ncia para a classe NextLevel

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Obt�m a refer�ncia para a classe NextLevel
        nextLevel = FindObjectOfType<NextLevel>();

    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void ApplyDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            // Notifica a classe NextLevel sobre a morte do inimigo
            nextLevel.OnEnemyDeath();

            // Instancia o objeto de coleta de sa�de
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);

            // Destr�i o inimigo
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Player>().OnHit(damage);
        }
    }

}
