using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil que o inimigo irá atirar
    public float shootingInterval = 2f; // Intervalo entre cada tiro
    private float shootTimer;

    void Start()
    {
        shootTimer = shootingInterval; // Inicializa o contador para o primeiro tiro
    }

    void Update()
    {
        // Contagem regressiva para o próximo tiro
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootingInterval; // Reinicia o contador
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null)
        {
            // Cria um projétil
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // Calcula a direção para o jogador
            Vector2 direction = (FindPlayerPosition() - (Vector2)transform.position).normalized;
            // Configura a direção do projétil
            projectile.GetComponent<EnemyProjectile>().SetDirection(direction);
        }
    }

    Vector2 FindPlayerPosition()
    {
        // Esta função localiza o jogador; ajuste conforme necessário para o seu jogo
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }
        return Vector2.zero; // Retorna um vetor zero se o jogador não for encontrado
    }
}
