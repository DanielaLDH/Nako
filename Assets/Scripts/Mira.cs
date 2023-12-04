using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    // Atualiza a mira na cena
    void Update()
    {
        // Obtém a posição do mouse na tela
        Vector3 mousePosition = Input.mousePosition;

        // Converte a posição do mouse de pixels para unidades do mundo
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Atualiza a posição da mira para a posição do mouse
        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
    }
}
