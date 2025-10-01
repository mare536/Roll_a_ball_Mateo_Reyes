using UnityEngine; // Espacio de nombres principal de Unity
using UnityEngine.InputSystem; // Para el sistema de entrada moderno de Unity
using TMPro; // Para mostrar texto en la UI

public class PlayerController : MonoBehaviour
{
    // Velocidad a la que se mueve el jugador.
    public float speed = 0;

    // Rigidbody del jugador para aplicar física.
    private Rigidbody rb;
    // Variables para almacenar el movimiento en los ejes X e Y.
    private float movementX;
    private float movementY;

    // Contador de objetos recogidos.
    private int count;
    // Referencia al texto de la UI que muestra el conteo.
    public TextMeshProUGUI countText;
    // Referencia al objeto de texto que muestra el mensaje de victoria.
    public GameObject winTextObject;

    public static bool isGameOver = false;

    // Start se llama antes de la primera actualización del frame.
    void Start()
    {
        // Obtener y almacenar el componente Rigidbody adjunto al jugador.
        rb = GetComponent<Rigidbody>();
        // Inicializa el contador de objetos recogidos.
        count = 0;
        // Actualiza el texto del contador en la UI.
        SetCountText();
        // Oculta el mensaje de victoria al inicio.
        winTextObject.SetActive(false);
    }

    // Esta función se llama cuando se detecta una entrada de movimiento.
    void OnMove(InputValue movementValue)
    {
        // Convierte el valor de entrada en un Vector2 para el movimiento.
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Almacena los componentes X e Y del movimiento.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate se llama una vez por frame de velocidad fija.
    void FixedUpdate()
    {
        // Crea un vector de movimiento 3D usando las entradas X e Y.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Aplica fuerza al Rigidbody para mover al jugador.
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isGameOver) return;
            isGameOver = true;
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Has Perdido!";
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            if (isGameOver) return;
            isGameOver = true;
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Te Has Quemado!";
        }
    }

    // Actualiza el texto del contador y muestra el mensaje de victoria si se han recogido suficientes objetos.
    void SetCountText()
    {
        // Actualiza el texto de la UI con el número de objetos recogidos.
        countText.text = "Count: " + count.ToString();
        // Si el jugador ha recogido 12 o más objetos, muestra el mensaje de victoria.
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            isGameOver = true;
            
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    // Se llama cuando el jugador entra en contacto con otro collider.
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona el jugador tiene la etiqueta "PickUp".
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Desactiva el objeto recogido para simular que ha sido recogido.
            other.gameObject.SetActive(false);
            // Incrementa el contador de objetos recogidos.
            count++;
            // Actualiza el texto del contador en la UI.
            SetCountText();
        }
    }
}
