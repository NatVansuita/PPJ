using UnityEngine;
using System.Collections;

public class PlayerMagnet : MonoBehaviour
{
    public float raioMagnet = 3f; // Raio de alcance do im�
    public float velocidadeAtracao = 5f; // Velocidade com que as moedas se movem at� o Player
    private bool magnetAtivo = false;

    public void AtivarMagnet(float duracao)
    {
        magnetAtivo = true;
        StartCoroutine(DesativarMagnet(duracao)); // Desativa o efeito ap�s o tempo determinado
    }

    void Update()
    {
        if (magnetAtivo)
        {
            AtrairMoedas();
        }
    }

    void AtrairMoedas()
    {
        GameObject[] premios = GameObject.FindGameObjectsWithTag("Premio");
foreach (GameObject premio in premios)
{
    float distancia = Vector2.Distance(transform.position, premio.transform.position);
    if (distancia <= raioMagnet)
    {
        premio.transform.position = Vector2.Lerp(premio.transform.position, transform.position, velocidadeAtracao * Time.deltaTime);
    }
}
    }

    IEnumerator DesativarMagnet(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        magnetAtivo = false; // Desativa o efeito ap�s o tempo determinado
    }
}