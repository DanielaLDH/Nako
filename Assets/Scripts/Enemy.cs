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
    private NextLevel nextLevel;// Referência para a classe NextLevel

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Obtém a referência para a classe NextLevel
        nextLevel = FindObjectOfType<NextLevel>();

    }

    private void Update()
    {
        MoveTowardsPlayer();

        if (player != null)
        {
           // Vector3 direction = player.position - transform.position;
            
            if (player.position.x > transform.position.x)
            {
                Debug.Log("normal");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("vira");

                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector3 globalMovement = transform.TransformDirection(direction);

            transform.Translate(globalMovement * speed * Time.deltaTime);
        }
    }

    public void ApplyDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            // Notifica a classe NextLevel sobre a morte do inimigo
            nextLevel.OnEnemyDeath();

            // Instancia o objeto de coleta de saúde
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);

            // Destrói o inimigo
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
