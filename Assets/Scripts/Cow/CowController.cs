using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum CowStatus
{
    Normal,
    Waiting,
    Sick,
    Hungry,
    Recovering
}

public class CowController : MonoBehaviour
{
    [Header("Random Decision Time")]
    public float MinDecisionTime = 5;
    public float MaxDecisionTime = 40;

    private float TimeToDecisionStatus;
    [Header ("Timer")]
    //public float TimeToDecisionStatus = 30;
    public float TimeToRecover = 5;

    [Header("Cuurent Status")]
    public CowStatus CurrentStatus = CowStatus.Normal;
    public Button ClickButton;

    [Header("Waiting UI")]
    public GameObject WaitingUI;

    [Header("Hungry UI")]
    public GameObject HungryUI;
    //public Button FeedButton;

    [Header("Sick UI")]
    public GameObject SickUI;
   

    [Header("Effect")]
    public GameObject HungryFX;
    public GameObject SickFX;

    public float timeCountdown = 0;

    public bool playerNearby = false;

    private void Start()
    {
        ClickButton.onClick.AddListener(TreatCow);
        RandomizeDecisionTime();
        SetStatus(CowStatus.Normal); // Start with normal status
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (CurrentStatus == CowStatus.Waiting)
            {
                RevealProblem();
            }
        }
    }

    private void RandomizeDecisionTime()
    {
        TimeToDecisionStatus = Random.Range(MinDecisionTime, MaxDecisionTime);

    }
    private void RevealProblem()
    {
        if (Random.Range(0, 100) >= 50)
        {
            SetStatus(CowStatus.Hungry);
        }
        else
        {
            SetStatus(CowStatus.Sick);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
    private void TreatCow()
    {

        //ClickButton.interactable = false;
        Debug.Log("BUTTON CLICK");
        HideAllUI();
        if (CurrentStatus == CowStatus.Sick)
        {
            SickFX.SetActive(true);
            
        }
        else if (CurrentStatus == CowStatus.Hungry)
        {
            HungryFX.SetActive(true);
            
        }
        StartCoroutine(Recover());
    }

    private void Update()
    {
        if (CurrentStatus == CowStatus.Normal)
        {
            timeCountdown += Time.deltaTime;
            if (timeCountdown >= TimeToDecisionStatus)
            {
                SetStatus(CowStatus.Waiting);
            }
        }
    }
    
    public void SetStatus(CowStatus newStatus)
    {
        CurrentStatus = newStatus;
        timeCountdown = 0; // Reset the countdown when status changes

        HideAllUI();
        HideAllFx();

        switch(newStatus) {
            case CowStatus.Normal:
                RandomizeDecisionTime();
                // No UI or FX for normal status
                break;
            case CowStatus.Waiting:
                WaitingUI.SetActive(true);

                break;
            case CowStatus.Hungry:
                HungryUI.SetActive(true);

                break;
            case CowStatus.Sick:
                SickUI.SetActive(true);

                break;
        }
    }

    private IEnumerator Recover() 
    {
        
        yield return new WaitForSeconds(TimeToRecover);
        SetStatus(CowStatus.Normal);
    }

    private void HideAllUI()
    {
        WaitingUI.SetActive(false);
        HungryUI.SetActive(false);
        SickUI.SetActive(false);
    }

    private void HideAllFx()
    {
        HungryFX.SetActive(false);
        SickFX.SetActive(false);
    }
}