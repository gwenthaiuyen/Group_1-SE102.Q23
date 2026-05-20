using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopSlotBuyItem : MonoBehaviour
{
    public TextMeshProUGUI NamePackTxt;
    public Button buttonBuy;

    private Animal animal;

    private void Start()
    {
        buttonBuy.onClick.AddListener(OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        StorageManager.Instance.AddAnimal(animal);
        SetData(animal); // Update the UI to reflect the purchase
    }

    public void SetData(Animal animal)
    {
        this.animal= animal;
        //NamePackTxt.text = animal.Name;
        if (StorageManager.Instance.IsAnimalBought(animal.Name))
        {
            buttonBuy.interactable = false;
        }
        else
        {
            buttonBuy.interactable = true;
        }
    }
}