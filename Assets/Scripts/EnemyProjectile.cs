using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f; // Velocidade do projétil
    private Vector2 direction; // Direção do movimento do projétil

    public int damage;


    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        // Mover o projétil
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Implemente a lógica de colisão conforme necessário
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().OnHit(damage);
            Destroy(gameObject); // Destrói o projétil após a colisão
        }
    }
}
