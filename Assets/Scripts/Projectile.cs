using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float distance = 100f;

    private Player playerStats;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        playerStats = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null) {
            collision.gameObject.GetComponent<Enemy>().Damage(playerStats.magicAttack);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 movement = new Vector3(projectileSpeed, 0f, 0f);
        transform.Translate(movement * Time.deltaTime);

        if(Vector3.Distance(transform.position, originalPosition) > distance)
        {
            Destroy(gameObject);
        }
    }
}
