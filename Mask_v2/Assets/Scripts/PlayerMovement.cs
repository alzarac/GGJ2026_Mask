using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int numeroCarriles = 5;
    public float distanciaEntreCarriles = 1f;

    int indiceActual = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            indiceActual++;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            indiceActual--;

        

        Vector3 pos = transform.position;
        pos.z = indiceActual * distanciaEntreCarriles;
        transform.position = pos;
    }
}

