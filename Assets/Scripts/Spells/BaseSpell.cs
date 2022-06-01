using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType { target, aoe, buff, none}
public enum ElementAffinity { fire, water, leaf, ground, electric, ice, light, dark }
public class BaseSpell : MonoBehaviour
{
    public SpellScriptableObject SpellSO;

    private CircleCollider2D spellCollider;

    private bool canCast = true;

    private void Awake()
    {
        spellCollider = GetComponent<CircleCollider2D>();
        spellCollider.isTrigger = true;
        spellCollider.radius = SpellSO.hitboxRadius;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpellSO.Speed > 0)
        {
            transform.Translate(transform.forward * SpellSO.Speed * Time.deltaTime);
        }
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
