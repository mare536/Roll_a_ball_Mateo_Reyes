using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Método para iniciar el juego, carga la escena del minijuego.
    public void Jugar()
    {
        SceneManager.LoadScene("Minigame"); // Cambia a la escena "Minigame"
    }

    // Método para salir del juego, cierra la aplicación.
    public void Salir()
    {
        Application.Quit(); // Cierra la aplicación
    }
}