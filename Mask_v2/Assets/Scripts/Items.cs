using UnityEngine;


public class Items : MonoBehaviour
{
    
    [Header("Target to Spin")]
    public GameObject target;       // Assign the object you want to spin

    [Header("Spin Settings")]
    public Vector3 rotationAxis = Vector3.up; // Axis to spin around (default: Y axis)
    public float rotationSpeed = 90f;         // Degrees per second


    void Start()
    {

    }

    void Update()
    {
        // Rotate the target
        target.transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.World);
    }


}

