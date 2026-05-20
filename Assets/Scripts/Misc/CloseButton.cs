using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class CloseButton : MonoBehaviour
{
    public GameObject PanelToClose;
    private Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;
    }
    public void OnClick()
    {
        StartCoroutine(ClickEffect());
    }
    IEnumerator ClickEffect()
    {
        transform.localScale = originalScale * 1.2f; // Scale up to 120%
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        transform.localScale = originalScale; // Reset to original scale
        PanelToClose.SetActive(false);
    }
}