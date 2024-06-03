using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    [Header("Equipment Components")]
    public Image equipArmourUI;
    public Image equipAccessoryUI;
    public Image equipSwordUI;
    public Image equipStaffUI;

    [Header("Get Player Stats and Inventory")]
    public GameObject player;
    private Player playerInventory;

    private void Awake()
    {
        playerInventory = player.GetComponent<Player>();
    }
    private void Start()
    {
        //Sets up equipment UI
        equipArmour();
        equipAccessory();
        equipSword();
        equipStaff();
    }

    public void equipArmour()
    {
        if (playerInventory.equipArmour != null)
        {
            equipArmourUI.sprite = playerInventory.equipArmour.icon;
        }
    }
    public void equipAccessory()
    {
        if (playerInventory.equipAccessory != null)
        {
            equipAccessoryUI.sprite = playerInventory.equipAccessory.icon;
        }
    }
    public void equipSword()
    {
        if (playerInventory.equipSword != null)
        {
            equipSwordUI.sprite = playerInventory.equipSword.icon;
        }
    }
    public void equipStaff()
    {
        if (playerInventory.equipStaff != null)
        {
            equipStaffUI.sprite = playerInventory.equipStaff.icon;
        }
    }
}
