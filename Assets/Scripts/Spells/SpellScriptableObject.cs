using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Fire, Water, Leaf }

[CreateAssetMenu(menuName = "Spells", fileName = "Spell Scriptable Object")]
public class SpellScriptableObject : ScriptableObject
{
    public float DamageAmount = 10f;
    public float AstralusCost = 10f;
    public string Description = "A spell";
    public float Cooldown;
    public float Lifetime = 5f;
    public float Speed = 3f;
    public float hitboxRadius = 1f;
    public Element Element = Element.Fire;


}
