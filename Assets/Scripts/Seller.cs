using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Seller : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Player Playerstorage;
    [SerializeField] private CoinManager coinManager;

    [SerializeField] private List<Item> itemPool = new List<Item>();
    [SerializeField] private int purchaseCost = 5;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void purchaseItem()
    {
        if (coinManager.coinCount >= purchaseCost)
        {
            animator.SetTrigger("Purchase");

            int randomNumber = Random.Range(0, itemPool.Count);
            Playerstorage.storage.Add(itemPool[randomNumber]);

            coinManager.coinCount -= purchaseCost;

            dialogueText.text = "Thanks for the purchase!";
        }
        else
        {
            dialogueText.text = "You don't have enough coins to make a purchase! Come back when you got some.";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && animator.GetBool("PlayerDetected"))
        {
            purchaseItem();
        }
    }
}
