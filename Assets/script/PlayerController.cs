using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    public float moveSpeed = 5f; // Velocidad de movimiento lateral
    public Transform groundCheck; // Punto de comprobación para detectar el suelo
    public float groundDistance = 0.1f; // Distancia para detectar el suelo
    public LayerMask groundMask; // Máscara de capas para el suelo

    private Rigidbody rb;
    private bool isGrounded; // Variable para verificar si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo usando un Collider
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Saltar automáticamente cuando está en el suelo
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Moverse hacia la izquierda y la derecha
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, rb.velocity.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador ha tocado un trigger con el tag "gameover"
        if (other.CompareTag("gameover"))
        {
            // Llama a la función CargarGameOver después de 3 segundos
            Invoke("CargarGameOver", 3f);
        }
    }

    void CargarGameOver()
    {
        // Cargar la escena de Game Over
        SceneManager.LoadScene("GameOverScene");
    }
}
