using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon {

    int damageUpgrade;
    float effDmgUpgrade;
    int pellets;
    float spread;
    float spreadAngle;
    int pellet;

    public void Load(XMLShotgun shotgunData) {
        name = shotgunData.weaponName;
        attackSpeed = shotgunData.attackSpeed;
        range = shotgunData.range;
        damage = shotgunData.damage;
        reloadSpeed = shotgunData.reloadSpeed;
        ammo = shotgunData.ammo;
        effectDamage = shotgunData.effectDamage;
        effectEfficiency = shotgunData.effectEfficiency;
        effectName = shotgunData.effectName;
        level = shotgunData.level;
        damageUpgrade = shotgunData.damageUpgrade;
        effDmgUpgrade = shotgunData.effDmgUpgrade;
        Set();
    }

    public override void Set() {
        pellets = 8;
        spread = 0.2f;
        spreadAngle = 2 * Mathf.PI / pellets;
        base.Set();
    }

    public override void SetMagazine() {
        bulletMagazine = new GameObject[ammo * pellets];
        base.SetMagazine();
    }

    public override void ReadyBullet(Bullet bullet, int magazineLocation) {
        Vector3 pelletOffset = new Vector3(spread * Mathf.Cos(pellet * spreadAngle), spread * Mathf.Sin(pellet * spreadAngle), 0);
        Vector3 originalLocalPos = transform.GetChild(0).localPosition;
        Vector3 offsetTarget = originalLocalPos + pelletOffset;
        transform.GetChild(0).localPosition = offsetTarget;
        Vector3 tempTarget = transform.GetChild(0).position - gameObject.transform.position;
        transform.GetChild(0).localPosition = originalLocalPos;
        tempTarget.Normalize();
        bullet.direction = tempTarget;
        bulletMagazine[magazineLocation].transform.position = transform.position;
        bulletMagazine[magazineLocation].transform.rotation = transform.rotation;
    }

    public override void Shoot() {
        for (int currentBullet = 0; currentBullet < bulletMagazine.Length; currentBullet+=pellets) {
            Bullet bullet = bulletMagazine[currentBullet].GetComponent<Bullet>();
            if (!bullet.inUse) {
                pellet = 0;
                for (int currentPellet = 0; currentPellet < pellets; ++currentPellet) {
                    bullet = bulletMagazine[currentBullet + currentPellet].GetComponent<Bullet>();
                    ReadyBullet(bullet, currentBullet + currentPellet);
                    bullet.Activate();
                    ++pellet;
                }
                return;
            }
        }
    }

    public override void LevelUp() {
        damage += damageUpgrade;
        effectDamage += effDmgUpgrade;
        base.LevelUp();
    }
}
