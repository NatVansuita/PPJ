using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

    public int valorMoeda = 1; // Valor da moeda ao ser coletada

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("A" + other.gameObject.tag + "A");
        if (other.CompareTag("Player")) // Verifica se o Player tocou na moeda
        {
              Destroy(gameObject); // Remove a moeda da cena
            GameManager.gm.UpdateScore(valorMoeda); // Adiciona pontos ao GameManager
          
        }
    }

}