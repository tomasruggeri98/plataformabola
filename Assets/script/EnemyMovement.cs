using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación del enemigo
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo de izquierda a derecha
    public float lifeTime = 10f; // Tiempo de vida del enemigo

    private float timer;

    void Start()
    {
        // Inicializar el temporizador para destruir el enemigo después de cierto tiempo
        timer = lifeTime;

        // Asignar una velocidad de movimiento inicial
        GetComponent<Rigidbody>().velocity = Vector3.right * moveSpeed;
    }

    void Update()
    {
        // Rotar el enemigo sobre su propio eje
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Reducir el temporizador
        timer -= Time.deltaTime;

        // Destruir el enemigo después de cierto tiempo
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar si el jugador ha tocado al enemigo
        {
            SceneManager.LoadScene("GameOverScene"); // Cargar la escena de GameOver
        }
    }
}

