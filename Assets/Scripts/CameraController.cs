using UnityEngine;
using static PlayerController; // Para acceder a la variable estática isGameOver

public class CameraController : MonoBehaviour
{
    // Referencia al GameObject del jugador.
    public GameObject player;
    // La distancia entre la cámara y el jugador.
    private Vector3 offset;

    // Start se llama una vez antes de la primera ejecución de Update después de que se crea el MonoBehaviour.
    void Start()
    {
        // Calcular el offset inicial entre la posición de la cámara y la posición del jugador.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate se llama una vez por frame después de que todas las funciones Update se hayan completado.
    void LateUpdate()
    {
        // Mantener el mismo offset entre la cámara y el jugador a lo largo del juego.
        if (!isGameOver) transform.position = player.transform.position + offset;
    }
}