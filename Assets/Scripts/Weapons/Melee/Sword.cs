using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon {

    public void Load(XMLSword swordData) {
        name = swordData.weaponName;
        attackSpeed = swordData.attackSpeed;
        damage = swordData.damage;
        effectCharge = swordData.effectCharge;
        effectName = swordData.effectName;
        level = swordData.level;
        attSpdUpgrade = swordData.attSpdUpgrade;
        damageUpgrade = swordData.damageUpgrade;    
        Set();
    }
}
