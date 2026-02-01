using TMPro;
using UnityEngine;

public class PlayerMovement_Update : MonoBehaviour
{

    public int numeroCarriles = 5;
    public float distanciaEntreCarriles = 1f;
    public float fuerzaSalto = 7f;
    public float alturaMaximaVelocidad = 8f;

    [Header("Transition Settings")]
    public float transitionSpeed = 5f; // Controls how fast the lane change happens

    private Rigidbody rb;
    private int indiceActual = 0;
    private Vector3 targetPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("No se encontró un Rigidbody en el GameObject.");

        // Start with current position as target
        targetPosition = transform.position;
    }

    public void PressArrow(bool value) { 
        print(value);

        if (value)
            indiceActual--;
        else
            indiceActual++;
        int limite = numeroCarriles / 2; // Asume número impar para tener carril central
        indiceActual = Mathf.Clamp(indiceActual, -limite, limite);
        // Update target position instead of teleporting
        targetPosition = new Vector3(transform.position.x, transform.position.y, indiceActual * distanciaEntreCarriles);

    }

    public void PressJump() {
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    void Update()
    {
        // Mover por carriles (izq = -1, der = +1)
        if (Input.GetKeyDown(KeyCode.RightArrow))
            indiceActual--;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            indiceActual++;

        int limite = numeroCarriles / 2; // Asume número impar para tener carril central
        indiceActual = Mathf.Clamp(indiceActual, -limite, limite);

        // Update target position instead of teleporting
        targetPosition = new Vector3(transform.position.x, transform.position.y, indiceActual * distanciaEntreCarriles);

        // Smooth transition toward target
        transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);

        // Saltar si presiona espacio y velocidad vertical casi cero (simple)
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }
}