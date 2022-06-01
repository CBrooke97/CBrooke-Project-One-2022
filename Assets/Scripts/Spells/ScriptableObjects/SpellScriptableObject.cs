using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Fire, Water, Leaf }

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{
    public float DamageAmount = 10f;
    public float AstralusCost = 10f;
    public string Description = "A spell";
    public float Cooldown;
    public float Liftime = 5f;
    public float Speed = 3f;
    public float hitboxRadius = 1f;
    public Element Element = Element.Fire;


}
