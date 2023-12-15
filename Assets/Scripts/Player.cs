using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float bulletSpeed;
    public int health;
    public float recoveryTime;

    public GameObject bulletPrefab;
    public GameObject gameOver;

    private PlayerAudio playerAudio;


    private bool recovery;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAudio.PlaySFX(playerAudio.attackSound);
            Shoot();

        }


    }

    // FixedUpdate is used for physics-related calculations
    void FixedUpdate()
    {
        HandleMovementInput();
        RotateTowardsMouse();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base na orientação do sprite
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normaliza o vetor de movimento para garantir que a diagonal não seja mais rápida
        movement.Normalize();

        Vector3 globalMovement = transform.TransformDirection(movement);


        // Move o jogador
        transform.Translate(globalMovement * speed * Time.deltaTime);

    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Flip o sprite na direção do mouse
        if (mousePos.x < transform.position.x)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


    public void OnHit(int dmg)
    {
        if (!recovery)
        {
            health -= dmg;
            playerAudio.PlaySFX(playerAudio.dmgSound);
            if (health <= 0)
            {
                Debug.Log("die");
                recovery = true;
                Time.timeScale = 1;
                gameOver.SetActive(true);
                Time.timeScale = 0f;

            }
            else
            {
                StartCoroutine(Recover());
            }
        }
    }

    public void IncreaseHealth(int amount)
    {
        if (health < 100) 
        {
            playerAudio.PlaySFX(playerAudio.healthPickSound);
            health += amount;
          
            Debug.Log(health);
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize(); // Normaliza o vetor para garantir que tenha comprimento 1

        // Crie o tiro na posição do jogador
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Rotacione o tiro na direção do mouse
        bullet.transform.up = direction;

        // Adicione uma força para movimentar o tiro
        bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 5f);
    }




    private IEnumerator Recover()
    {
        recovery = true;
        yield return new WaitForSeconds(recoveryTime);
        recovery = false;

    }
}
