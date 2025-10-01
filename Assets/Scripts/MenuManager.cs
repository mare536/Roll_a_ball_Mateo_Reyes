using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void Salir()
    {
        Application.Quit();
    }
}