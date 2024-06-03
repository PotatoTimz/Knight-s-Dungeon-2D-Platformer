using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;

    [SerializeField] private List<Item> itemPool = new List<Item>();

    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            int randomNumber = Random.Range(0, itemPool.Count);
            print(itemPool[randomNumber].name + " has been selected from the pool");
            collision.gameObject.GetComponent<Player>().storage.Add(itemPool[randomNumber]);
            animator.SetTrigger("Open");
        }
    }
}
