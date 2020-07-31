using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MeleeWeapon {

    public void Load(XMLAxe axeData) {
        name = axeData.weaponName;
        attackSpeed = axeData.attackSpeed;
        damage = axeData.damage;
        effectCharge = axeData.effectCharge;
        level = axeData.level;
        attSpdUpgrade = axeData.attSpdUpgrade;
        damageUpgrade = axeData.damageUpgrade;
        effectName = axeData.effectName;
        Set();
    }
}
