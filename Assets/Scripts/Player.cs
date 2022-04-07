using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DamageHandler(float value);
public delegate void AstralusHandler(float value);

public class Player : MonoBehaviour
{
    //Player stats
    #region PlayerStats

    [Header("Player Stats")]
    public float maxHealth;
    public float currentHealth;
    public float maxAstralus;
    public float currentAstralus;

    public int level = 1;
    public float maxExperience;
    public float currentExperience;

    public string playerName;
    public float moveSpeed = 5f;

    public Vector2 jump = new Vector2(0.0f, 1.0f);
    public float jumpForce = 5.0f;
    public int jumpCount = 2;

    #endregion

    public event DamageHandler DamageEvent;
    public event AstralusHandler AstralusEvent;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateHealthBar();
            OnAstralusUpdate();
        }
    }

    public void GainExp(float amount)
    {
        float expGain = currentExperience + amount;
        if (expGain > maxExperience)
        {
            float carryExp = (currentExperience + amount) - maxExperience;
            level++;
            maxExperience *= 1.2f;
            currentExperience = carryExp;
        }
        else
        {
            currentExperience = expGain;
        }
    }

    public void ApplyDamage(int amount)
    {
        if (currentHealth - amount <= 0)
        {
            //death logic here
        }
        else if (currentHealth - amount > 0)
        {
            currentHealth -= amount;
            UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        //Debug.Log("Health Updated");
        DamageEvent?.Invoke(currentHealth/maxHealth);
    }

    public void OnAstralusUpdate()
    {
        AstralusEvent?.Invoke(currentAstralus/maxAstralus);
        Debug.Log("Astralus Updated");
    }
}
