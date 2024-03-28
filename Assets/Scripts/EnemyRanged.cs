using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til que o inimigo ir� atirar
    public float shootingInterval = 2f; // Intervalo entre cada tiro
    private float shootTimer;

    void Start()
    {
        shootTimer = shootingInterval; // Inicializa o contador para o primeiro tiro
    }

    void Update()
    {
        // Contagem regressiva para o pr�ximo tiro
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
            // Cria um proj�til
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // Calcula a dire��o para o jogador
            Vector2 direction = (FindPlayerPosition() - (Vector2)transform.position).normalized;
            // Configura a dire��o do proj�til
            projectile.GetComponent<EnemyProjectile>().SetDirection(direction);
        }
    }

    Vector2 FindPlayerPosition()
    {
        // Esta fun��o localiza o jogador; ajuste conforme necess�rio para o seu jogo
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }
        return Vector2.zero; // Retorna um vetor zero se o jogador n�o for encontrado
    }
}
