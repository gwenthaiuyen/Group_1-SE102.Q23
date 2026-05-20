using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [Header("Top bar")]
    public TextMeshProUGUI GoldQuantityText;
    public TextMeshProUGUI EnergyQuantityText;

    public Button gotoMartScene;
    public Button gotoFramScene;

    private void Start()
    {
        if (gotoFramScene != null)
            gotoFramScene.onClick.AddListener(GotoFarmScene);

        if (gotoMartScene != null)
            gotoMartScene.onClick.AddListener(GotoMartScene);
    }

    private void GotoFarmScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Farm");
    }

    private void GotoMartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mart");
    }

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateQuantityText();
    }

    public void UpdateQuantityText()
    {
        var goldLootItem = StorageManager.Instance.GetLootByName("Vang");
        //var energyLootItem = StorageManager.Instance.GetLootByName("Energy");

        GoldQuantityText.SetText(goldLootItem.Quantity.ToString());
        //EnergyQuantityText.SetText(energyLootItem.Quantity.ToString());
    }
}