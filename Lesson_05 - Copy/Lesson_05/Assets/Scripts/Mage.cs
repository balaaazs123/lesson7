using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BaseClassScript
{
    public int Mana { get; set; }
    public int Intelligence { get; set; }
    public bool Potatoification { get; set; }

    public Mage()
    {
        Intelligence = 5;
        ClassName = "Potato Mage";
        Health = 80;
        Strength = 4;
        Agility = 3;
        Damage = Strength / 2;
        AbilityDamage = 6 * Intelligence; 
        Mana = 100;
        Potatoification = false;
    }
}
