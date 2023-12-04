using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acido : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Player>().OnHit(damage);
        }
    }
}
