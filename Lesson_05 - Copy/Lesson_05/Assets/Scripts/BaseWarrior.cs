using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarrior : BaseClassScript
{

    public bool Kick { get; set; }

    public BaseWarrior()
    {
        ClassName = "Warrior";
        Health = 100;
        Strength = 5;
        Agility = 3;
        Damage = 5 * Strength;
        AbilityDamage = 2 * Damage;
        Kick = false;
    }

    public BaseWarrior(int health, int strength, int agility)
    {
        ClassName = "Warrior";
        Health = health;
        Strength = strength;
        Agility = agility;
        Damage = 5 * Strength;
        AbilityDamage = 2 * Damage;
        Kick = false;
    }

}
