using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float tiempoDeVida = 10f; // Tiempo en segundos antes de destruir el objeto

    void Start()
    {
        // Llama a la función de destrucción después del tiempo de vida especificado
        Destroy(gameObject, tiempoDeVida);
    }
}
