using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DamageHandler(float value);
public delegate void AstralusHandler(float value);

public class Player : MonoBehaviour
{
    //Player stats
    #region PlayerStats
    
    public CharStats PlayerStats;
    public string playerName;
    public float moveSpeed = 5f;

    public Vector2 jump = new Vector2(0.0f, 1.0f);
    public float jumpForce = 5.0f;
    public int jumpCount = 2;

    #endregion

    
    //Event handlers for updating health and mana bars upon value changes
    public event DamageHandler DamageEvent;
    public event AstralusHandler AstralusEvent;

    private void Awake()
    {
        PlayerStats = GetComponent<CharStats>();
    }

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

    //Applies damage to player stats
    public void ApplyDamage(int amount)
    {
        //If damage amount is greater than or equal to remaining health, kill entity.
        if (PlayerStats.CurrentHealth - amount <= 0)
        {
            //death logic here
        }
        //If current health is greater than the damage value, subtract damage amount from current health.
        else if (PlayerStats.CurrentHealth - amount > 0)
        {
            PlayerStats.TakeDamage(amount);
            UpdateHealthBar();
        }
    }

    //Invokes the damage event once health value is changed, triggering health bar to update.
    public void UpdateHealthBar()
    {
        //Debug.Log("Health Updated");
        print(PlayerStats.CurrentHealth);
        print(PlayerStats.MaxHealth);
        DamageEvent?.Invoke(PlayerStats.CurrentHealth/PlayerStats.MaxHealth);
    }

    //Invokes mana bar event upon mana value change, triggering mana bar update.
    public void OnAstralusUpdate()
    {
        AstralusEvent?.Invoke(PlayerStats.CurrentAstralus/PlayerStats.MaxAstralus);
        Debug.Log("Astralus Updated");
    }
}
