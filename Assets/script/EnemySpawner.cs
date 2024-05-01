using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a spawnear
    public float minSpawnInterval = 3f; // Intervalo de tiempo m�nimo entre cada spawn
    public float maxSpawnInterval = 10f; // Intervalo de tiempo m�ximo entre cada spawn
    public float spawnRangeY = 10f; // Rango vertical en el que se spawnean los enemigos
    public GameObject player; // Referencia al jugador

    private float timer;

    void Start()
    {
        // Inicializar el temporizador con un valor aleatorio dentro del rango inicial
        timer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Contador para spawnear enemigos
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Obtener la posici�n actual del jugador
            float playerY = player.transform.position.y;

            // Generar una posici�n de spawn aleatoria dentro del rango Y en relaci�n con la posici�n del jugador
            float randomY = Random.Range(playerY - spawnRangeY, playerY + spawnRangeY);

            // Generar una posici�n de spawn en el eje X cerca del spawner
            float randomX = transform.position.x;

            // Vector de posici�n de spawn
            Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);

            // Spawnear un nuevo enemigo en la posici�n generada
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Reiniciar el temporizador con un valor aleatorio dentro del nuevo rango
            timer = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}
