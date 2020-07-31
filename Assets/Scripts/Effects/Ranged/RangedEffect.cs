using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEffect : MonoBehaviour {

    float duration;
    int strength;
    string stat;
    float damage;

	public void Load(XMLRangedEffect effectData) {
        damage = effectData.damage;
        stat = effectData.debuffedStat;
        strength = effectData.strength;
        duration = effectData.duration;
    }

    public void ActivateEffect(GameObject enemy) {
        //set effect name and damage
        Debug.Log(stat);
        enemy.GetComponent<TestEnemy>().EnemyEffect(stat, strength, duration);
    }
}
