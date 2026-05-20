using UnityEngine;

public class OpenStorageCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            UIManager.Instance.Storage.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            UIManager.Instance.Storage.gameObject.SetActive(false);
    }
}