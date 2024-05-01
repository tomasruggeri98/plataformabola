using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform centerPoint; // El transform del objeto alrededor del cual quieres orbitar
    public float orbitSpeed = 1f; // Velocidad de la órbita

    void Update()
    {
        // Calcula la dirección del vector desde el centro al asteroide
        Vector3 orbitDirection = (centerPoint.position - transform.position).normalized;

        // Calcula el ángulo de rotación
        float rotationAngle = orbitSpeed * Time.deltaTime;

        // Calcula el vector de rotación alrededor del eje vertical del objeto
        Vector3 rotationAxis = Vector3.up;

        // Aplica la rotación
        transform.RotateAround(centerPoint.position, rotationAxis, rotationAngle);
    }
}

