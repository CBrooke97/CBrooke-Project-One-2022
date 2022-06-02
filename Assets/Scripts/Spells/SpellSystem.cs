using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    [SerializeField] private CharStats playerStats;
    private bool isCasting = false;
    //[SerializeField] private Transform castPoint;

    [SerializeField] private BaseSpell spellToCast;
    [SerializeField] private int spellIndex = 0;

    void Start()
    {
        playerStats = GetComponent<CharStats>();
        spellToCast = playerStats.Spells[spellIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCasting && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CastSpell());
        }

        if (!isCasting && Input.GetKeyDown(KeyCode.Q))
        {
            IncrementSpell();
        }
    }

    private IEnumerator CastSpell()
    {
        isCasting = true;
        print("Casting Spell");
        InstantiateSpell();

        yield return new WaitForSeconds(2f);

        isCasting = false;
        print("Can Cast");
    }

    public void InstantiateSpell()
    {
        // Spawn spell
        Instantiate(spellToCast, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void IncrementSpell()
    {
        if(spellIndex < playerStats.Spells.Length)
        {
            spellIndex++;
            spellToCast = playerStats.Spells[spellIndex];
        }
        else
        {
            spellIndex = 0;
            spellToCast = playerStats.Spells[spellIndex];
        }
    }
}
