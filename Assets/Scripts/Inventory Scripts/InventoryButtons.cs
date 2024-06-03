using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

using System;
using TMPro;

public class InventoryButtons : MonoBehaviour
{
    [Header("Get Player Stats and Inventory")]
    [SerializeField] private GameObject player;
    private Player playerInventory;

    [Header("Storage and Equipment Manager")]
    [SerializeField] private GameObject storage;
    private StorageManager storageManager;
    [SerializeField] private GameObject equipment;
    private EquipmentManager equipmentManager;

    [Header("Featured Item and Stats Viewer UI")]
    [SerializeField] private GameObject featuredItem;
    [SerializeField] private GameObject statOverlay;

    [Header("Toggle view mode")]
    [SerializeField] Image toggleStatsButton;
    [SerializeField] Image toggleDeleteButton;
    [SerializeField] private bool toggleStatViewer = false;
    [SerializeField] private bool toggleTrashMode = false;
    [SerializeField] private Sprite closedBook;
    [SerializeField] private Sprite openBook;
    [SerializeField] private Sprite bombUnlit;
    [SerializeField] private Sprite bombLit;

    [Header("Featured Item components")]
    [SerializeField] private Image highlightImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemTypeText;
    [SerializeField] private TMP_Text itemDescriptionText;

    [Header("Stats Viewer Components")]
    [SerializeField] private TMP_Text playerStatsText;

    private void Start()
    {
        storageManager = storage.GetComponent<StorageManager>();   
        playerInventory = player.GetComponent<Player>();
        equipmentManager = equipment.GetComponent<EquipmentManager>();
        toggleViewMode();
        generateStats();
    }

    private void toggleViewMode()
    {
        if(!toggleStatViewer)
        {
            featuredItem.SetActive(true);
            toggleStatsButton.sprite = openBook;
            statOverlay.SetActive(false);
        }
        else
        {
            featuredItem.SetActive(false);
            toggleStatsButton.sprite = closedBook;
            statOverlay.SetActive(true);
        }
    }

    private void highlightItem(Item item)
    {
        highlightImage.sprite = item.icon;
        print(item.icon);
        itemNameText.text = item.name;
        itemTypeText.text = item.type;
        itemDescriptionText.text = item.description;
    }

    public void clickToggleStatViewer()
    {
        if(toggleStatViewer)
        {
            toggleStatViewer = false;
            toggleViewMode();
        }
        else
        {
            toggleStatViewer = true;
            toggleViewMode();
        }
    }
    public void clickToggleTrashViewer()
    {
        if (!toggleTrashMode)
        {
            toggleTrashMode = true;
            toggleDeleteButton.sprite = bombLit;
        }
        else
        {
            toggleTrashMode = false;
            toggleDeleteButton.sprite = bombUnlit;
        }
        print("trashmode" + toggleTrashMode.ToString());
    }
    public void clickStorageButton()
    {
        //finds the inventory spot that was clicked and than updates it inside current loadout within the player class
        int buttonName = Int32.Parse(EventSystem.current.currentSelectedGameObject.name);
        Item item = playerInventory.storage[buttonName];

        if (!toggleTrashMode)
        {
            highlightItem(item);
            playerInventory.EquipItem(item, buttonName);
            generateStats();

            //print("Equiping" + item.name);

            //updates the icon under equipment
            if (item.type == "Armour")
            {
                equipmentManager.equipArmour();
            }
            else if (item.type == "Accessory")
            {
                equipmentManager.equipAccessory();
            }
            else if (item.type == "Weapon")
            {
                equipmentManager.equipSword();
            }
            else if (item.type == "Staff")
            {
                equipmentManager.equipStaff();
            }
        }
        else
        {
            playerInventory.storage.Remove(item);
        }
        //updates the storage ui
        storageManager.createStorageUI();
    }

    public void generateStats()
    {
        string playerStatSheet = "Offensive Stats\n" +
                                 "Physical Attack: " + playerInventory.physicalAttack +
                                 "\nMagic Attack: " + playerInventory.magicAttack +
                                 "\nAttack Speed: " + playerInventory.attackSpeed +
                                 "\n\nDefensive Stat\n" +
                                 "Defence: " + playerInventory.defence +
                                 "\nMax Health: " + playerInventory.maxHealth +
                                 "\nMax Mana: " + playerInventory.maxMana;

        playerStatsText.text = playerStatSheet;
    }
    public void clickArmourButton()
    {
        Item item = playerInventory.equipArmour;
        highlightItem(item);
    }
    public void clickAccessoryButton()
    {
        Item item = playerInventory.equipAccessory;
        highlightItem(item);
    }
    public void clickWeaponButton()
    {
        Item item = playerInventory.equipSword;
        highlightItem(item);
    }
    public void clickStaffButton()
    {
        Item item = playerInventory.equipStaff;
        highlightItem(item);
    }
}
