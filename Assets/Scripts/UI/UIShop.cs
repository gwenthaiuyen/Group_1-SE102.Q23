using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public List<Animal> AnimalDatabase = new List<Animal>();
    public List<UIShopSlotBuyItem> ShopSlots = new List<UIShopSlotBuyItem>();

    private void Start()
    {
       // hide all shop slots at the start
        foreach (var slot in ShopSlots)
        {
            slot.gameObject.SetActive(false);
        }

        // populate shop slots with animals from the database
        for (int i = 0; i < AnimalDatabase.Count; i++)
        {
            ShopSlots[i].SetData(AnimalDatabase[i]);
            ShopSlots[i].gameObject.SetActive(true);
        }
    }
}