using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
