using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Player player;
    public Bullet bullet;

    public GameObject powerUps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthUp()
    {
        player.health += 5;
        powerUps.SetActive(false);
        Time.timeScale = 1f;

    }

    public void SpeedUp()
    {
        player.speed += 5;
        powerUps.SetActive(false);
        Time.timeScale = 1f;


    }

    public void DamageUp() 
    {
        bullet.damage += 5;
        powerUps.SetActive(false);
        Time.timeScale = 1f;


    }
}
