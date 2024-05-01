using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 5f;
    public float spawnDistanceY = 5f; // Distancia vertical entre las plataformas
    public float platformLifeTime = 6f; // Tiempo de vida de cada plataforma

    private float lastPlatformY;
    private float timer;

    void Start()
    {
        timer = spawnInterval;
        lastPlatformY = transform.position.y; // Posición inicial de generación de la primera plataforma
    }

    void Update()
    {
        // Contador para generar plataformas
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Generar una nueva plataforma a una distancia constante vertical
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, lastPlatformY + spawnDistanceY, 0f);
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            // Destruir la plataforma después de un tiempo
            Destroy(newPlatform, platformLifeTime);

            lastPlatformY = spawnPosition.y; // Actualizar la posición de la última plataforma generada
            timer = spawnInterval;
        }
    }
}

