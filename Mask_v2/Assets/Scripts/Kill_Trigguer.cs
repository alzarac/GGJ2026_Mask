using UnityEngine;

public class Killer_Trigguer : MonoBehaviour
{
    public GameOver muere; 

    void OnTriggerEnter(Collider col)
        {
            
            if (col.gameObject.CompareTag("Player"))
            {
                Destroy(col.gameObject);
                muere.Setup();
            }
            
        }
}
