using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Collider playerCollider;
    public Canvas mainCanvas;
    public TMP_Text happyFaceText;
    public TMP_Text sadFaceText;
    public TMP_Text angryFaceText;
    public int maxpoits = 2;
    public AudioSource Audioobjeto;
    public AudioSource Audiomorir;
    public GameOver GameOver;

    private bool yaGano = false;

    void OnTriggerEnter(Collider other)
    {
        if (yaGano) return;

        // Pasamos el texto, el nombre y EL �NDICE de la escena
        if (other.gameObject.CompareTag("Mask_Angry"))
        {
            ActualizarPuntaje(other, angryFaceText, "Enojada", 4);
            Audioobjeto.Play();
        }
        else if (other.gameObject.CompareTag("Mask_Sad"))
        {
            ActualizarPuntaje(other, sadFaceText, "Triste", 3);
            Audioobjeto.Play();
        }
        else if (other.gameObject.CompareTag("Mask_Happy"))
        {
            ActualizarPuntaje(other, happyFaceText, "Feliz", 5);
            Audioobjeto.Play();
        }
        else if (other.gameObject.CompareTag("KillCollider"))
        {
            Audiomorir.Play();
            print("Player fall!");
            GameOver.Setup();
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Audiomorir.Play();
            print("Player fall!");
            GameOver.Setup();
            
        }


    }

    // A�adimos 'int indiceEscena' como par�metro
    void ActualizarPuntaje(Collider col, TMP_Text textoUI, string tipo, int indiceEscena)
    {
        print($"Player hit an {tipo}!");

        if (col.gameObject.transform.parent != null)
            Destroy(col.gameObject.transform.parent.gameObject);
        else
            Destroy(col.gameObject);

        int puntos = int.Parse(textoUI.text) + 1;
        textoUI.text = puntos.ToString();

        if (puntos >= maxpoits)
        {
            yaGano = true;
            print($"�Ganaste! Personalidad: {tipo}. Cargando escena {indiceEscena}");

            // Carga la escena espec�fica que le pasamos
            SceneManager.LoadScene(indiceEscena);
        }
    }
}

