using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Collider playerCollider;

  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit an obstacle!");
            // Handle collision with obstacle (e.g., reduce health, end game, etc.)
        }
    }
}
