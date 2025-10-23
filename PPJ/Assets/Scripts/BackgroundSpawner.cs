using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [Header("Configuração dos Fundos")]
    public GameObject[] backgrounds; // Prefabs dos fundos
    public float spawnDistance = 38f; // Distância entre os fundos
    public Transform player; // Referência ao jogador ou câmera
    public float destroyOffset = 30f; // Quando destruir fundos antigos

    private float lastSpawnX;

    private List<GameObject> spawnedBackgrounds = new List<GameObject>();

    void Start()
    {
        lastSpawnX = transform.position.x;
        SpawnBackground();
    }

    void Update()
    {
        if (player.position.x >= lastSpawnX)
        {
            SpawnBackground();
        }

        DestroyOldBackgrounds();
    }

    void SpawnBackground()
    {
        Vector3 spawnPosition = new Vector3(lastSpawnX + spawnDistance, transform.position.y, transform.position.z);
        GameObject newBackground = Instantiate(backgrounds[Random.Range(0, backgrounds.Length)], spawnPosition, Quaternion.identity);
        spawnedBackgrounds.Add(newBackground);

        lastSpawnX += spawnDistance;
    }

    void DestroyOldBackgrounds()
    {
        for (int i = spawnedBackgrounds.Count - 1; i >= 0; i--)
        {
            if (player.position.x - spawnedBackgrounds[i].transform.position.x > destroyOffset)
            {
                Destroy(spawnedBackgrounds[i]);
                spawnedBackgrounds.RemoveAt(i);
            }
        }
    }
}