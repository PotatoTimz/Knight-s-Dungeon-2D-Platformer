using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpStat : MonoBehaviour
{
    [SerializeField] private string statType = "Health";
    [SerializeField] private int increaseValue = 10;

    [SerializeField] private float rotationSpeed = 130f;
    private float rotationAngle = 0f;

    [SerializeField] private float upDownSpeed = 1f;
    [SerializeField] private float upDownDistance = 2f;
    private Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player playerStats = collision.gameObject.GetComponent<Player>();

        if (statType == "Health")
        {
            playerStats.HealDamage(increaseValue);
            print("Player has been healed to " + playerStats.currentHealth);
        }
        else if (statType == "Mana")
        {
            playerStats.GainMana(increaseValue);
            print("Player has gained mana to " + playerStats.currentMana);

        }
        Destroy(gameObject);
    }

    private void Update()
    {
        rotationAngle += rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        transform.position = new Vector3(initPosition.x, Mathf.Sin(Time.time * upDownSpeed) * upDownDistance + initPosition.y, 0);
    }
}
