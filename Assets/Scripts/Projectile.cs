using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int setDamage;
 

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

    private void Start()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();
        int nmrCena = cenaAtual.buildIndex;
        if (nmrCena == 1) 
        {
            damage = setDamage;
        }
    }
}
