using System;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    /// luu tru tat ca cac tai nguyen cua minh
    public static StorageManager Instance;
    public List<LootItem> LootItemsInGames = new List<LootItem>();
    public List<Animal> AnimalsInGames = new List<Animal>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddAnimal(Animal animal)
    {
        AnimalsInGames.Add(animal);
    }

    public Animal GetAnimalByName(string animalName)
    {
        foreach (var animal in AnimalsInGames)
        {
            if (animal.Name == animalName) 
                return animal;
        }
        return null;
    }

    public LootItem GetLootByName(string lootName)
    {
        foreach (var item in LootItemsInGames)
        {
            if (item.Name == lootName) 
                return item;
        }
        return null;
    }

    public void EarnLootItem(string lootName, int quantity)
    {
        var lootItem = GetLootByName(lootName);
        lootItem.Quantity += quantity;
    }

    public void SpendLootItem(string lootName, int quantity)
    {
        var lootItem = GetLootByName(lootName);
        if (lootItem.Quantity < quantity)
        {
            Debug.Log("Khong duoc phep tieu vi khong du tai nguyen: " + lootItem.Quantity + " < " + quantity);
            return;
        }
        lootItem.Quantity -= quantity;
    }

    public bool IsAnimalBought(string name)
    {
        foreach (var animal in AnimalsInGames)
        {
            if (animal.Name == name) 
                return true;
        }
        return false;
    }
}


[System.Serializable]
public class LootItem
{
    public string Name;
    public string Description;
    public int Quantity;
}


[System.Serializable]
public class Animal
{
    public string Name;
    public bool IsMale;
    public string Description;
    public bool HasFeed;
}