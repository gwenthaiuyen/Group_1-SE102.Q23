using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum CowStatus
{
    Normal,
    Sick,
    Hungry,
    Recovering
}

public class CowController : MonoBehaviour
{
    public float TimeToDecisionStatus = 30;
    public float TimeToRecover = 5;
    public CowStatus CurrentStatus = CowStatus.Normal;
    public GameObject CowStatusUI;
    public Button StatusButton;
    public GameObject RecoveringFX;

    public float timeCountdown = 0;

    private void Start()
    {
        StatusButton.onClick.AddListener(StatusClicked);
        SetStatus(CowStatus.Normal); // Start with normal status
    }

    private void StatusClicked()
    {
        SetStatus(CowStatus.Normal); // test
    }

    private void Update()
    {
        if (CurrentStatus == CowStatus.Normal)
        {
            timeCountdown += Time.deltaTime;
            if (timeCountdown >= TimeToDecisionStatus)
            {
                // Randomly decide if the cow becomes sick or hungry
                if (Random.Range(0, 100) >= 50)
                {
                    SetStatus(CowStatus.Sick);
                }
                else
                {
                    SetStatus(CowStatus.Hungry);
                }
                timeCountdown = 0; // Reset the countdown
            }
        }
    }
    
    public void SetStatus(CowStatus newStatus)
    {
        timeCountdown = 0; // Reset the countdown when status changes

        if (newStatus != CowStatus.Normal && newStatus != CowStatus.Recovering)
        {
            RecoveringFX.SetActive(false);
            CurrentStatus = newStatus;
            CowStatusUI.SetActive(true); // Show the UI when the cow is not normal
        }
        else
        {
            // chuyen ve normal
            CowStatusUI.SetActive(false); // Hide the UI when the cow is normal
            if (CurrentStatus == CowStatus.Normal)
            {
                RecoveringFX.SetActive(false);
                return; // No need to change status if it's already normal
            }

            CurrentStatus = CowStatus.Recovering; // Reset status to normal
            RecoveringFX.SetActive(true); // Show recovering effect
            StartCoroutine(Recover());
        }
    }

    private IEnumerator Recover() 
    {    
        yield return new WaitForSeconds(TimeToRecover);
        CurrentStatus = CowStatus.Normal; // Automatically recover to normal after the specified time
        RecoveringFX.SetActive(false);
    }
}