using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangedWeapon {

    float rangeUpgrade;
    float reloadSpdUpgrade;

    public void Load(XMLPistol pistolData) {
        name = pistolData.weaponName;
        attackSpeed = pistolData.attackSpeed;
        range = pistolData.range;
        damage = pistolData.damage;
        reloadSpeed = pistolData.reloadSpeed;
        ammo = pistolData.ammo;
        effectDamage = pistolData.effectDamage;
        effectEfficiency = pistolData.effectEfficiency;       
        effectName = pistolData.effectName;
        level = pistolData.level;
        rangeUpgrade = pistolData.rangeUpgrade;
        reloadSpdUpgrade = pistolData.reloadUpgrade;       
        Set();
    }

    public override void SetMagazine() {
        bulletMagazine = new GameObject[ammo];
        base.SetMagazine();
    }

    public override void LevelUp() {
        range += rangeUpgrade;
        reloadSpeed += reloadSpdUpgrade;
        base.LevelUp();
    }
}
