using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Player player;
    private float Vida;
    public Image Barra;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vida = player.health;
        Debug.Log(Vida);
        Barra.fillAmount = Vida/100;
    }
}