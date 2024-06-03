using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private SpriteRenderer enemySprite;

    [Header("Enemy Stats")]
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int hp = 100;
    [SerializeField] public int attack = 10;
    [SerializeField] public int defense = 5;

    public void Damage(int damageInflicted)
    {
        int damageTaken = damageInflicted - defense;
        //if the defense of an enemy is higher than the players attack deals 0
        if(damageTaken < 0)
        {
            damageTaken = 0;
        }
        print("Enemy has recieved " + damageTaken + " damage");
        hp -= damageTaken;
        StartCoroutine(FlashRed());
        if (hp <= 0)
        {
            animator.SetTrigger("isDead");
        }
    }

    private IEnumerator FlashRed()
    {
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
    }

    private void Update()
    {
        if (animator == null)
        {
            Destroy(gameObject);
        }
    }
}
