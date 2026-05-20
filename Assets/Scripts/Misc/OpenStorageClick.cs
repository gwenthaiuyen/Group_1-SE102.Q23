using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenStorageClick : MonoBehaviour
{
    public GameObject StoragePanel;
    private Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    public void OnClick()
    {
        StartCoroutine(ClickEffect());
    }

    IEnumerator ClickEffect()
    {
        transform.localScale = originalScale * 1.2f; // Scale down to 90%
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        transform.localScale = originalScale; // Reset to original scale
        StoragePanel.SetActive(true);
    }
}
