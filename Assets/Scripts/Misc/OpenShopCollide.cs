using UnityEngine;

public class OpenShopCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            UIManager.Instance.Shop.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            UIManager.Instance.Shop.gameObject.SetActive(false);
    }
}