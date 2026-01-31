using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int numeroCarriles = 5;
    public float distanciaEntreCarriles = 1f;
    public float fuerzaSalto = 7f;
    public float alturaMaximaVelocidad = 8f;

    private Rigidbody rb;
    private int indiceActual = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("No se encontró un Rigidbody en el GameObject.");
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

        Vector3 pos = transform.position;
        pos.z = indiceActual * distanciaEntreCarriles;
        transform.position = pos;

        // Saltar si presiona espacio y velocidad vertical casi cero (simple)
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

    }
}

