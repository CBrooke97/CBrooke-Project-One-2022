using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType { target, aoe, buff, none}
public enum ElementAffinity { fire, water, leaf, ground, electric, ice, light, dark }
public class BaseSpell : MonoBehaviour
{
    public SpellScriptableObject SpellCast;

    private CircleCollider2D spellCollider;

    private void Awake()
    {
        spellCollider = GetComponent<CircleCollider2D>();
        spellCollider.isTrigger = true;
        spellCollider.radius = SpellCast.hitboxRadius;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCast()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Apply spell
        Destroy(this.gameObject);
    }

    public IEnumerator OnCooldown(float cd)
    {
        canCast = false;
        yield return new WaitForSeconds(cd);
        canCast = true;
    }
}
