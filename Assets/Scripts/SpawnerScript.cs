using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Configuração dos Objetos a Gerar")]
    public GameObject[] vetor;
    public float spawnInterval = 2f; // Tempo entre os spawns

    [Header("Movimento do Spawner")]
    public float spawnerSpeed = 2f; // Velocidade que o Spawner avança no eixo X

    [Header("Variação no Spawn")]
    public float spawnYRange = 2f; // Apenas variação vertical (altura)

    private float timer = 0f;

    void Update()
    {
        // Move o Spawner para frente no eixo X
        transform.position += Vector3.right * spawnerSpeed * Time.deltaTime;

        // Timer para spawnar
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.y += Random.Range(-spawnYRange, spawnYRange);
        Instantiate(vetor[Random.Range(0, vetor.Length)], spawnPos, Quaternion.identity);
    }
}