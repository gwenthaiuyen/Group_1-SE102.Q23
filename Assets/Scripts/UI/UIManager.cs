using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public UIMenu Menu;
    public UIShop Shop;
    public UIStorage Storage;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Menu.Show();
    }
}