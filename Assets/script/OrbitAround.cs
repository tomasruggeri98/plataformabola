using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform centerPoint; // El transform del objeto alrededor del cual quieres orbitar
    public float orbitSpeed = 1f; // Velocidad de la �rbita

    void Update()
    {
        // Calcula la direcci�n del vector desde el centro al asteroide
        Vector3 orbitDirection = (centerPoint.position - transform.position).normalized;

        // Calcula el �ngulo de rotaci�n
        float rotationAngle = orbitSpeed * Time.deltaTime;

        // Calcula el vector de rotaci�n alrededor del eje vertical del objeto
        Vector3 rotationAxis = Vector3.up;

        // Aplica la rotaci�n
        transform.RotateAround(centerPoint.position, rotationAxis, rotationAngle);
    }
}

