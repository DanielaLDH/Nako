using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public void SetDamage(int amount)
    {
        damage = amount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Aplica o dano ao inimigo
            other.GetComponent<Enemy>().ApplyDamage(damage);

            // Destroi a bala
           Destroy(gameObject);
        }
    }
}
