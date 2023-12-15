using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int lvlIndex;
    public int qtdeEnemy;

    private Collider2D mycollider;

    private int enemyDeaths = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(lvlIndex);
        }


    }
    private void AtivaCollider()
    {
        if (qtdeEnemy <= enemyDeaths)
        {
            mycollider.isTrigger = true;
        }
    }

    // Método chamado pelo inimigo quando morre
    public void OnEnemyDeath()
    {
        // Incrementa a contagem de mortes de inimigos
        enemyDeaths++;

        // Exibe ou utiliza a informação conforme necessário
        Debug.Log("Inimigos derrotados: " + enemyDeaths);

        // Adicione aqui qualquer lógica adicional relacionada à contagem de inimigos derrotados
    }

    private void Start()
    {
        // Inicializa a contagem de mortes de inimigos
        enemyDeaths = 0;

        mycollider = GetComponent<Collider2D>();

        Scene cenaAtual = SceneManager.GetActiveScene();
        int nmrCena = cenaAtual.buildIndex;
        if ( nmrCena != 1 & nmrCena != 4)
        {   
            Debug.Log(nmrCena + "oi");
            Time.timeScale = 0f;
            
        }
    }

    private void Update()
    {
        AtivaCollider();
    }
}


