using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    //prefab of storage slot
    [SerializeField] private GameObject storageSlot;
    
    [Header("Get Player Stats and Inventory")]
    [SerializeField] private GameObject player;
    private Player playerInventory;

    private void Awake()
    {
        playerInventory = player.GetComponent<Player>();
        createStorageUI();
    }
    public void createStorageUI()
    {
        if(playerInventory.storage != null) { 
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }

            int counter = 0;
            foreach (Item inventoryItem in playerInventory.storage)
            {
                GameObject button = Instantiate(storageSlot, transform).gameObject.transform.GetChild(0).gameObject;
                button.gameObject.name = counter.ToString();
                button.gameObject.GetComponent<Image>().sprite = inventoryItem.icon;
                button.gameObject.GetComponent<Image>().sprite = inventoryItem.icon;

            
                button.gameObject.GetComponent<Button>().onClick.AddListener(
                    GameObject.FindWithTag("InventoryUI").GetComponent<InventoryButtons>().clickStorageButton);

                counter++;
            }
        }
    }
}
