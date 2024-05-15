using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Jugar (string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
   public void Salir ()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");

    }
}
