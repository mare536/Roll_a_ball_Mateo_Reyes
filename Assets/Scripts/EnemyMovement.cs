using UnityEngine; // Importa el espacio de nombres principal de Unity
using UnityEngine.AI; // Importa el sistema de navegación de Unity

public class EnemyMovement : MonoBehaviour
{
    // Referencia al transform del jugador para poder seguirlo
    public Transform player;
    // Referencia al componente NavMeshAgent que permite mover al enemigo usando la malla de navegación
    private NavMeshAgent navMeshAgent;

    // Start se llama una vez antes de la primera actualización del frame
    void Start()
    {
        // Obtiene el componente NavMeshAgent del enemigo
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Si existe una referencia al jugador, el enemigo lo sigue
        if (player != null)
        {
            // Establece la posición del jugador como destino del enemigo
            navMeshAgent.SetDestination(player.position);
        }   
    }
}
