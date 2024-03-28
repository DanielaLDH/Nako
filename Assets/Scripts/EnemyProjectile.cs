using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f; // Velocidade do proj�til
    private Vector2 direction; // Dire��o do movimento do proj�til

    public int damage;


    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        // Mover o proj�til
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Implemente a l�gica de colis�o conforme necess�rio
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().OnHit(damage);
            Destroy(gameObject); // Destr�i o proj�til ap�s a colis�o
        }
    }
}
