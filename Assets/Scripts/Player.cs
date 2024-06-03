using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Player : MonoBehaviour
{
    [Header("Savable Stats")]
    [SerializeField] public int numOfClears = 0;
    [SerializeField] public int numOfDeaths = 0;

    [Header("Offensive Player Stats")]
    [SerializeField] public int physicalAttack = 5;
    [SerializeField] public int magicAttack = 5;
    [SerializeField] public float attackSpeed = 0f;

    [Header("Defensive Player Stats")]
    [SerializeField] public int defence = 0;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int maxMana = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int currentMana;


    [Header("Player Inventory")]
    [SerializeField] public List<Item> storage = new List<Item>();
    [SerializeField] public Item equipArmour;
    [SerializeField] public Item equipAccessory;
    [SerializeField] public Item equipSword;
    [SerializeField] public Item equipStaff;

    [Header("Misc")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] public SaveLoadData saveManager;
    private CharacterController2D fall;

    public bool collided = false;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ManaBar manaBar;
    [SerializeField] public CoinManager coinManager;


    private float originalX;
    private float originalY;
    private bool fell = false;
    void Awake()
    {
        saveManager = gameObject.GetComponent<SaveLoadData>();

        // Update Stats according to equiped items
        if (equipArmour != null)
        {
            EquipItem(equipArmour);
        }
        if (equipAccessory != null)
        {
            EquipItem(equipAccessory);
        }
        if (equipSword != null)
        {
            EquipItem(equipSword);
        }
        if (equipStaff != null)
        {
            EquipItem(equipStaff);
        }

        originalX = transform.position.x;
        originalY = transform.position.y;
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
        manaBar.SetMana(maxMana);

        SavedData save = saveManager.LoadFromJson();
        if (save == null)
        {
            print("No save data found");
        }
        else
        {
            numOfDeaths = save.numOfDeaths;
            numOfClears = save.numOfClears;
            coinManager.coinCount = save.coinAmount;
        }
    }

    public void EquipItem(Item item)
    {
        physicalAttack += item.physicalAttack;
        magicAttack += item.magicAttack;
        attackSpeed += item.attackSpeed;
        defence += item.defence;
        maxHealth += item.healthBuff;
        maxMana += item.manaBuff;
    }

    public void EquipItem(Item item, int itemNumber)
    {
        //stores item to be equiped
        Item tempItem = storage[itemNumber];
        storage.RemoveAt(itemNumber);

        //unequip current item than equip new item
        if (item.type == "Armour")
        {
            storage.Insert(itemNumber, equipArmour);
            UnequipItem(equipArmour);
            equipArmour = item;
        }
        else if (item.type == "Accessory")
        {
            storage.Insert(itemNumber, equipAccessory);
            UnequipItem(equipAccessory);
            equipAccessory = item;
        }
        else if (item.type == "Weapon")
        {
            storage.Insert(itemNumber, equipSword);
            UnequipItem(equipSword);
            equipSword = item;
        }
        else if (item.type == "Staff")
        {
            storage.Insert(itemNumber, equipStaff);
            UnequipItem(equipStaff);
            equipStaff = item;
        }

        physicalAttack += item.physicalAttack;
        magicAttack += item.magicAttack;
        attackSpeed += item.attackSpeed;
        defence += item.defence;
        maxHealth += item.healthBuff;
        maxMana += item.manaBuff;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }

    public void UnequipItem(Item item)
    {
        physicalAttack -= item.physicalAttack;
        magicAttack -= item.magicAttack;
        attackSpeed -= item.attackSpeed;
        defence -= item.defence;
        maxHealth -= item.healthBuff;
        maxMana -= item.manaBuff;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        gameOverScreen.Setup(); // Enable the GameOverScreen
        PauseGame(); // Pause all game activity
    }

    // Pause the game
    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    // Call this method when you want to resume game activity, e.g., after closing the GameOverScreen
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void HealDamage(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        StartCoroutine(FlashGreen());
    }
    public void GainMana(int mana)
    {
        currentMana += mana;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.SetMana(currentMana);
        StartCoroutine(FlashBlue());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        StartCoroutine(collisionWait());
        Enemy collidedEnemy = collision.gameObject.GetComponent<Enemy>();

        if (collidedEnemy != null && collided == true)
        {
            int damageRecieved = collidedEnemy.attack - defence;
            if (damageRecieved < 0)
            {
                damageRecieved = 0;
            }
            print("Player has recieved " + damageRecieved + " damage");
            TakeDamage(damageRecieved);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() == null)
        {
            collided = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            originalX = collision.transform.position.x;
            originalY = collision.transform.position.y;
            Debug.Log("Checkpoint reached");
        }
    }

    private IEnumerator FlashRed()
    {
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.white;
    }
    private IEnumerator FlashGreen()
    {
        playerSprite.color = Color.green;
        yield return new WaitForSeconds(0.3f);
        playerSprite.color = Color.white;
    }
    private IEnumerator FlashBlue()
    {
        playerSprite.color = Color.blue;
        yield return new WaitForSeconds(0.3f);
        playerSprite.color = Color.white;
    }

    private IEnumerator collisionWait()
    {
        yield return new WaitForSeconds(100f);
    }

    private void fallDamage()
    {
        if (fell == true)
        {
            TakeDamage(40);
            fell = false;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -10.0f)
        {
            transform.localPosition = new Vector3(originalX, originalY, 0);
            fell = true;
            fallDamage();
        }
    }
}
