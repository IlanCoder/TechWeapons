using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class LoaderManager : MonoBehaviour {
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    void Start() {
        foreach (XMLSword sword in XMLManager.ins.meleeWeaponDB.swordList) {
            if (sword.weaponName == "Wind Sword") {
                item1.GetComponent<Sword>().Load(sword);
            }
        }
        
        foreach (XMLAxe axe in XMLManager.ins.meleeWeaponDB.axeList) {
            if (axe.weaponName == "Dragon Axe") {
                item2.GetComponent<Axe>().Load(axe);
            }
        }

        foreach (XMLPistol pistol in XMLManager.ins.rangedWeaponDB.pistolList) {
            if (pistol.weaponName == "Lighting Pistol") {
                item3.GetComponent<Pistol>().Load(pistol);
            }
        }

        foreach (XMLShotgun shotgun in XMLManager.ins.rangedWeaponDB.shotgunList) {
            if (shotgun.weaponName == "Freeze Shotgun") {
                item4.GetComponent<Shotgun>().Load(shotgun);
            }
        }
    }

    //Loads XMlEffectData of the especified effecr
    public static XMLMeleeEffect LoadMeleeEffect(string name) {
        foreach (XMLMeleeEffect effect in XMLManager.ins.meleeEffectDB.meleeEffList) {
            if (effect.effectName == name) {
                return effect;
            }
        }
        return null;
    }

    public static XMLRangedEffect LoadRangeEffect(string name) {
        foreach (XMLRangedEffect effect in XMLManager.ins.rangedEffectDB.rangedEffList) {
            if (effect.effectName == name) {
                return effect;
            }
        }
        return null;
    }
}
