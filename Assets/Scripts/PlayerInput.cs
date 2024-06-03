using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;

    private CharacterController2D controller;
    public Animator animator;
    [SerializeField] private GameObject inventory;
    [SerializeField] private StorageManager storageManager;

    private float horizontalMove = 0f;
    private bool jump = false;

    [Header ("Attacking")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] public GameObject attackEffect;
    [SerializeField] private float attackCoolDown;
    private float lastAttack;


    [Header("Cast")]
    [SerializeField] private Transform projectilePoint;
    [SerializeField] public GameObject projectileEffect;
    [SerializeField] public float castCoolDown;
    [SerializeField] private int castCost;
    private float lastCast;
    [SerializeField] private ManaBar manaBar;

    private Player playerStats;

    private void Start() {
        playerStats = GetComponent<Player>();
        controller = GetComponent<CharacterController2D>();
        lastAttack = Time.time; 
        lastCast= Time.time;
        //turns of inventory on startup
        inventory.SetActive(false);
    }

    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Moving", Mathf.Abs(controller.speed));

        if (Input.GetButtonDown("Jump")) {
            jump = true;

            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.P) && controller.isGrounded && (Time.time > lastAttack))
        {
            print(playerStats.attackSpeed);
            lastAttack = Time.time + (attackCoolDown - playerStats.attackSpeed);
            if(lastAttack < 0)
            {
                lastAttack = 0;
            }
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.O) && controller.isGrounded && (Time.time > lastCast) && playerStats.currentMana >= castCost)
        {
            lastCast = Time.time + castCoolDown;
            Cast();

            playerStats.currentMana -= castCost;
            print(playerStats.currentMana);
            manaBar.SetMana(playerStats.currentMana);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
            }
            else if (!inventory.activeSelf) 
            {
                inventory.SetActive(true);
                storageManager.createStorageUI();
            }
        }

        if (controller.isGrounded)
        {
            animator.SetBool("Falling", false);
        }
        else if(!controller.isGrounded)
        {
            animator.SetBool("Falling", true);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemiesHit)
        {
            if (controller.isFacingRight)
            {
                Instantiate(attackEffect, enemy.transform.position, Quaternion.Euler(0, -180, 0));
            }
            else if (!controller.isFacingRight)
            {

                Instantiate(attackEffect, enemy.transform.position, Quaternion.Euler(0, 0, 0));
            }

            enemy.GetComponent<Enemy>().Damage(playerStats.physicalAttack);

        } 
    }

    private void Cast()
    {
        animator.SetTrigger("Cast");
        if (controller.isFacingRight)
        {
            Instantiate(projectileEffect, projectilePoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (!controller.isFacingRight)
        {
            Instantiate(projectileEffect, projectilePoint.position, Quaternion.Euler(0, 180, 0));

        }
        Stunned(3);
    }

    private IEnumerator Stunned(float stopTime)
    {
        yield return new WaitForSeconds(stopTime);
    }

    private void FixedUpdate() {
        // movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);

        jump = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public float LastCast
    {
        get { return lastCast; }
        set { lastCast = value; } // Allow external modification
    }

}
