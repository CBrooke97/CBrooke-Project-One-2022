using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    //Variable to store instance of player stats.
    [SerializeField] private CharStats playerStats;

    //Bool used to check if the player is casting or has cast recently, preventing spam casting of spells.
    private bool isCasting = false;
    //[SerializeField] private Transform castPoint;

    //Instance of spell being cast.
    [SerializeField] private BaseSpell spellToCast;
    //Index in the array of player spells currently selected to cast.
    [SerializeField] private int spellIndex = 0;

    void Start()
    {
        //Retrieves player stats and sets initial spell to cast.
        playerStats = GetComponent<CharStats>();
        spellToCast = playerStats.Spells[spellIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for player input and if the player is already casting.
        if(!isCasting && Input.GetMouseButtonDown(0))
        {
            //Checks if the player has the mana available to cast the selected spell.
            if (spellToCast.SpellSO.AstralusCost <= playerStats.CurrentAstralus)
            {
                playerStats.SpendAstralus(spellToCast.SpellSO.AstralusCost);
                StartCoroutine(CastSpell());
            }
            else
            {
                print("Not enough Astralus to cast this spell.");
            }
        }

        //Hotkey to swap currently selected spell.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncrementSpell();
        }
    }

    //Coroutine for casting the spell and placing it on a cooldown.
    private IEnumerator CastSpell()
    {
        isCasting = true;
        playerStats.isRechargingAstralus = false;
        InstantiateSpell();

        yield return new WaitForSeconds(2f);

        isCasting = false;
        playerStats.isRechargingAstralus = true;
    }

    //Creates an instance of the spell at target spawn location, ready for use.
    public void InstantiateSpell()
    {
        // Spawn spell
        Instantiate(spellToCast, gameObject.transform.position, gameObject.transform.rotation);
    }

    //Method for swapping currently selected spell.
    private void IncrementSpell()
    {
        //Increments spell index if not yet at array length limit.
        if(spellIndex < playerStats.Spells.Length - 1)
        {
            
            spellIndex++;
            print(spellIndex);
            spellToCast = playerStats.Spells[spellIndex];
        }
        //Resets index to 0 if array length limit reached.
        else
        {
            spellIndex = 0;
            print(spellIndex);
            spellToCast = playerStats.Spells[spellIndex];
        }
    }
}
