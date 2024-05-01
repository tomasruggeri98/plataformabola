using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al objeto de texto en el que se mostrará el score
    public float tiempoParaAumentarScore = 1f; // Tiempo en segundos para aumentar el score

    private int score = 0;
    private float timer = 0f;

    void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Si el temporizador alcanza el tiempo especificado, aumentar el score y reiniciar el temporizador
        if (timer >= tiempoParaAumentarScore)
        {
            score++;
            ActualizarTextoScore();
            timer = 0f;
        }
    }

    void ActualizarTextoScore()
    {
        // Actualizar el texto del score en pantalla
        scoreText.text = score.ToString();
    }
}

