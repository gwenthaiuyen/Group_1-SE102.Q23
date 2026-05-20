using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public List<AnimalGameObject> Animals;
    private void Start()
    {
        ShowOrHideAnimals();
    }

    private void ShowOrHideAnimals()
    {
        var animalsIsUnlock = StorageManager.Instance.AnimalsInGames;
        // hide all animal for init, if the animal is unlock  or lock=>just hide it
        foreach (var animal in Animals)
        {
            animal.gameObject.SetActive(false);
        }


        foreach (var animal in Animals)
        {
            foreach (var animalUnlocked in animalsIsUnlock)
            {
                if (animalUnlocked.Name == animal.AnimalName)
                {
                    animal.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}