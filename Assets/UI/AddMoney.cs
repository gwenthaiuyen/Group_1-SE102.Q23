using IrishFarmSim;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    public string LootName;
    public int Quantity;
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StorageManager.Instance.EarnLootItem(LootName, Quantity);
            UIManager.Instance.Menu.UpdateQuantityText();

            gameObject.SetActive(false);
        }
    }
}
