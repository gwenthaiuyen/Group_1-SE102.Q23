using UnityEngine;

public class UIAutoLookatCamera : MonoBehaviour
{
    private Transform mainCamera;
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }
    private void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera);
        }
    }
}