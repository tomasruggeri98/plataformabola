using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarButton : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        // Cargar la escena principal
        SceneManager.LoadScene("game");
    }
}
