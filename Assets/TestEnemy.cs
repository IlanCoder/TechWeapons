using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour {

    delegate void EffectUpdate();
    EffectUpdate effectUpdate;
    float effectStrength;
    float effectDuration;

    void Start () {
	}
	void Update () {
        if(effectUpdate!=null)
            effectUpdate();
    }
    
    public void EnemyEffect(string debuffedStat, int strenght, float duration)  {
        effectStrength = (float)strenght / 100f;
        effectDuration= duration;
        if (debuffedStat == "Speed"){
            effectUpdate = SlowEffectUpdate;
        }
        if (debuffedStat == "Damage") {
            effectUpdate = DamageEffectUpdate;
        }
    }

    void SlowEffectUpdate() {
        if (effectDuration > 0) {
            Debug.Log("Speed is: " + (1 - effectStrength) + ", time left" + effectDuration);
            effectDuration -= Time.deltaTime;
        } else { effectUpdate = null; }
    }
    
    void DamageEffectUpdate() {
        if (effectDuration > 0) {
            Debug.Log("Damage is: " + (1 - effectStrength) + ", time left" + effectDuration);
            effectDuration -= Time.deltaTime;
        } else { effectUpdate = null; }
    }
}
