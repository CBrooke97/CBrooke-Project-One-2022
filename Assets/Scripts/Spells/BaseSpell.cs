using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType { target, aoe, buff, none}
public enum ElementAffinity { fire, water, leaf, ground, electric, ice, light, dark }
public class BaseSpell : MonoBehaviour
{
    public SpellScriptableObject SpellSO;

    private CircleCollider2D spellCollider;

    private Vector2 mouseWorldPosition;
    private Vector2 fireDirection;

    private bool canCast = true;

    private void Awake()
    {
        spellCollider = GetComponent<CircleCollider2D>();
        spellCollider.isTrigger = true;
        spellCollider.radius = SpellSO.hitboxRadius;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Destroy(this.gameObject, SpellSO.Lifetime);
    }

    // Start is called before the first frame update
    void Start()
    {
        fireDirection = mouseWorldPosition - new Vector2(transform.position.x, transform.position.y);
        fireDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = fireDirection * SpellSO.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpellSO.Speed > 0)
        {
            
        }
    }

    public void OnCast()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Apply spell

        if(collision.gameObject.tag == "Player")
        {
            print("hit player");
        }
        else if (collision.gameObject.tag == "Damageable")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<CharStats>().TakeDamage(SpellSO.DamageAmount);
            Destroy(this.gameObject);
        }
        
    }

    public IEnumerator OnCooldown(float cd)
    {
        canCast = false;
        yield return new WaitForSeconds(cd);
        canCast = true;
    }
}
