using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    [Header("Velocidade de Movimento")]
    public float speed = 2f; // Velocidade que o Destroyer avança no eixo X

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        // Move o Destroyer no eixo X (sempre para frente)
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Debug.Log("Jogador colidiu com o destruidor!");
            Time.timeScale = 0;
            return;
        }
        else
        {
            Debug.Log("Destruído: " + outro.gameObject.name);
            if (outro.transform.parent)
                Destroy(outro.transform.parent.gameObject);
            else
                Destroy(outro.gameObject);
        }
    }
}