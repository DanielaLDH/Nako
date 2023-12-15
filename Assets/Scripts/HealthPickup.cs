using System.Collections;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount;
    public float timeToDestroy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(healthAmount);
            // Aplica o aumento de vida ao jogador
            other.GetComponent<Player>().IncreaseHealth(healthAmount);

            StopCoroutine("WaitAndDestroy");

            // Destroi o consumível
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(gameObject);
    }
}
