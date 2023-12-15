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
        bullet.damage = bullet.setDamage;
    }

    public void SpeedUp()
    {
        player.speed += 5;
        powerUps.SetActive(false);
        Time.timeScale = 1f;
        bullet.damage = bullet.setDamage;


    }

    public void DamageUp() 
    {
        bullet.damage = bullet.setDamage + 1;
        powerUps.SetActive(false);
        Time.timeScale = 1f;


    }
}
