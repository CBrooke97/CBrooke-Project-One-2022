using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spell application type 
public enum SpellType { target, aoe, buff, none}
//Spell damage type
public enum ElementAffinity { fire, water, leaf, ground, electric, ice, light, dark }
public class BaseSpell : MonoBehaviour
{
    //Scriptable object which holds base information of the spell.
    public SpellScriptableObject SpellSO;

    //Collider for applying spell effects.
    private CircleCollider2D spellCollider;

    //Vectors required to fire the spell in the direction of the mouse.
    private Vector2 mouseWorldPosition;
    private Vector2 fireDirection;

    //Bool to prevent spam casting of spells.
    private bool canCast = true;

    private void Awake()
    {
        //Stores attached collider as a variable and enables it as a trigger.
        spellCollider = GetComponent<CircleCollider2D>();
        spellCollider.isTrigger = true;

        //Sets collider radius to predefined size in the spells scriptable object.
        spellCollider.radius = SpellSO.hitboxRadius;

        //Retrieves current mouse position in the world and stores it for firing the spell.
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Destroy(this.gameObject, SpellSO.Lifetime);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculates the directional vector from the current world position and the mouses position at time of spawning.
        fireDirection = mouseWorldPosition - new Vector2(transform.position.x, transform.position.y);
        fireDirection.Normalize();

        //Applies velocity to the spell using directional vector and predefined speed from the spell scriptable object.
        GetComponent<Rigidbody2D>().velocity = fireDirection * SpellSO.Speed;
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
        //Apply spell to hit target.

        ApplySpell(collision);
        
    }

    public virtual void ApplySpell(Collider2D collision)
    {
        //If player is hit.
        if (collision.gameObject.tag == "Player")
        {
            print("hit player");
        }
        //Applies spell effect to damageable object before destorying itself.
        else if (collision.gameObject.tag == "Damageable")
        {
            collision.GetComponent<DamageableTerrain>().CompareElement(SpellSO.Element);
            Destroy(this.gameObject);
        }
        //Applies spell effect to enemy before destroying itself.
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<CharStats>().TakeDamage(SpellSO.DamageAmount);
            Destroy(this.gameObject);
        }
    }

    //Coroutine preventing spam casting of spells by placing it on predefined cooldown from spell scriptable object.
    public IEnumerator OnCooldown(float cd)
    {
        canCast = false;
        yield return new WaitForSeconds(cd);
        canCast = true;
    }
}
