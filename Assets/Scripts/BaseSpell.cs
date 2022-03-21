using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType { target, aoe, buff, movement, none}
public enum ElementAffinity { fire, water, leaf, ground, electric, ice, light, dark }
public class BaseSpell : MonoBehaviour
{
    public float damage;
    public float astralusCost;
    public ElementAffinity affinity;
    public SpellType type;
    public float coodlown;
    public bool canCast;

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

    public IEnumerator OnCooldown(float cd)
    {
        canCast = false;
        yield return new WaitForSeconds(cd);
        canCast = true;
    }
}
