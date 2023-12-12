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


    private bool recovery;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    // FixedUpdate is used for physics-related calculations
    void FixedUpdate()
    {
        HandleMovementInput();
       // RotateTowardsMouse();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime);

        transform.Translate(movement);
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = Vector2.Lerp(transform.up, direction, rotationSpeed * Time.deltaTime);
    }

    public void OnHit(int dmg)
    {
        //anim
        health -= dmg;
        //sound
        if (health <= 0) 
        {
            Debug.Log("die");
            recovery = true;
            Time.timeScale = 1;
            gameOver.SetActive(true);
            
        }
        else
        {
            StartCoroutine(Recover());
        }
    }

    public void IncreaseHealth(int amount)
    {
        if (health < 100) 
        {
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
