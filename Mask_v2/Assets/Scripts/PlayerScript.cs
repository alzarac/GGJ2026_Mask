using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Collider playerCollider;
    public Canvas mainCanvas;
    public TMP_Text happyFaceText;
    public TMP_Text sadFaceText;
    public TMP_Text angryFaceText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mask_Angry")
        {
           print("Player hit an Angry!");
            // Handle collision with obstacle (e.g., reduce health, end game, etc.)
            Destroy(other.gameObject.transform.parent.gameObject);
            angryFaceText.text = (int.Parse(angryFaceText.text) + 1).ToString();
        }

        if (other.gameObject.tag == "Mask_Sad")
        {
            print("Player hit an Sad!");
            // Handle collision with obstacle (e.g., reduce health, end game, etc.)
            Destroy(other.gameObject.transform.parent.gameObject);
            sadFaceText.text = (int.Parse(sadFaceText.text) + 1).ToString();
        }

        if (other.gameObject.tag == "Mask_Happy")
        {
            print("Player hit an Happy!");
            // Handle collision with obstacle (e.g., reduce health, end game, etc.)
            Destroy(other.gameObject.transform.parent.gameObject);
            happyFaceText.text = (int.Parse(happyFaceText.text) + 1).ToString();
        }
    }
}
