using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenenoScript : MonoBehaviour
{
 
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que entrou no colisor � o Player
        {
            GameManager.gm.EndGame(); // Chama o m�todo para reduzir a sa�de no GameManager
        }
    }

}