using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float[] posicionesZ = { -2f, 0f, 2f }; 
    int indiceActual = 1; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            indiceActual++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            indiceActual--;
        }

        indiceActual = Mathf.Clamp(indiceActual, 0, posicionesZ.Length - 1);

        Vector3 pos = transform.position;
        pos.z = posicionesZ[indiceActual];
        transform.position = pos;
    }
}

