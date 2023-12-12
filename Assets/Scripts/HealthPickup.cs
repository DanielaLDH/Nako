using System.Collections;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(healthAmount);
            // Aplica o aumento de vida ao jogador
            other.GetComponent<Player>().IncreaseHealth(healthAmount);

            // Destroi o consumível
            Destroy(gameObject);
        }
    }
}
