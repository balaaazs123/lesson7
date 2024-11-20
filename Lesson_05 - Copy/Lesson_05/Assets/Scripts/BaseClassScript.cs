using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClassScript : MonoBehaviour
{
    private string className;
    private int health;
    private int strength;
    private int agility;
    private int damage;
    private int abilityDamage;

    public string ClassName { get { return className; } set { className = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int Strength { get { return strength; } set { strength = value; } }
    public int Agility { get { return agility; } set { agility = value; } }
    public int Damage{ get { return damage; } set { damage = value; }}
    public int AbilityDamage { get { return abilityDamage; } set { abilityDamage = value; } }

}
