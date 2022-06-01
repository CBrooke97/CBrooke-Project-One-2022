using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int currentExp;
    [SerializeField] private int maxExp;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float astralusRechargeRate = 1f;

    [SerializeField] public BaseSpell[] Spells = new BaseSpell[3];

    public float CurrentHealth
    {
        get
        { return currentHealth; }
    }
    public float MaxHealth { get; set; }


    [SerializeField] private float currentAstralus;
    [SerializeField] private float maxAstralus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float value)
    {
        if(currentHealth - value <= 0)
        {
            //Death code here
        }
        else
        {
            currentHealth -= value;
        }
    }

    public void Heal(float value)
    {
        if (currentHealth + value >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth + value < maxHealth && currentHealth + value > currentHealth)
        {
            currentHealth += value;
        }
    }
}
