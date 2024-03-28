using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab_melee;
    public GameObject enemyPrefab_ranged;

    [System.Serializable]
    public class Wave
    {
        public int numberOfEnemies_melee;
        public int numberOfEnemies_ranged;
        public float spawnInterval; // Intervalo entre inimigos dentro da mesma onda
    }

    public float waveInterval; // Intervalo entre ondas
    public List<Wave> waves = new List<Wave>();
    private int currentWaveIndex = 0;
    private Wave currentWave;
    private float spawnTimer = 0f;
    private float waveTimer = 0f;
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                SpawnEnemy();
                if (currentWave.numberOfEnemies_melee > 0 || currentWave.numberOfEnemies_ranged > 0)
                {
                    spawnTimer = currentWave.spawnInterval;
                }
                else
                {
                    // Terminou a onda atual, prepare-se para a próxima
                    isSpawning = false;
                    waveTimer = waveInterval; // Começa a contar o intervalo para a próxima onda
                }
            }
        }
        else if (waveTimer > 0)
        {
            // Aguardando o intervalo entre ondas
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0f)
            {
                // Intervalo terminou, comece a próxima onda
                StartNextWave();
            }
        }
    }

    void StartNextWave()
    {
        if (currentWaveIndex < waves.Count)
        {
            currentWave = waves[currentWaveIndex];
            spawnTimer = currentWave.spawnInterval;
            isSpawning = true;
            currentWaveIndex++; // Prepara-se para a próxima onda
        }
    }

    void SpawnEnemy()
    {
        // Verifica e instancia um inimigo de corpo a corpo (melee) se necessário
        if (currentWave.numberOfEnemies_melee > 0)
        {
            Vector2 randomSpawnPos_melee = (Vector2)transform.position + Random.insideUnitCircle * 5f; // Supondo um raio de spawn fixo
            Instantiate(enemyPrefab_melee, randomSpawnPos_melee, Quaternion.identity);
            currentWave.numberOfEnemies_melee--; // Decrementa o contador de inimigos de corpo a corpo
        }

        // Verifica e instancia um inimigo à distância (ranged) se necessário
        if (currentWave.numberOfEnemies_ranged > 0)
        {
            Vector2 randomSpawnPos_ranged = (Vector2)transform.position + Random.insideUnitCircle * 5f; // Supondo um raio de spawn fixo
            Instantiate(enemyPrefab_ranged, randomSpawnPos_ranged, Quaternion.identity);
            currentWave.numberOfEnemies_ranged--; // Decrementa o contador de inimigos à distância
        }
    }

}
