using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

[System.Serializable]
public class Item : MonoBehaviour
{
    [Header("Descriptors")]
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public string type;


    [Header("Offensive Stat Modifiers")]
    [SerializeField] public int physicalAttack;
    [SerializeField] public int magicAttack;
    [SerializeField] public float attackSpeed;

    [Header("Defensive Stat Modifiers")]
    [SerializeField] public int defence;
    [SerializeField] public int healthBuff;
    [SerializeField] public int manaBuff;


    [Header("Misc")]
    [SerializeField] public Sprite icon;

    public Item()
    {
        this.name = "";
        this.description= string.Empty;
        this.type= string.Empty;
        this.physicalAttack = 0;
        this.magicAttack = 0;
        this.attackSpeed= 0;
        this.defence= 0;
        this.healthBuff= 0;
        this.manaBuff = 0;
        this.icon= null;
    }

    public Item(string name, string description, string type, int physicalAttack, int magicAttack, float attackSpeed, int defence, int healthBuff, int manaBuff, Sprite icon)
    {
        this.name = name;
        this.description= description;
        this.type= type;
        this.physicalAttack = physicalAttack;
        this.magicAttack = magicAttack;
        this.attackSpeed= attackSpeed;
        this.defence= defence;
        this.healthBuff= healthBuff;
        this.manaBuff = manaBuff;
        this.icon= icon;
    }
}
