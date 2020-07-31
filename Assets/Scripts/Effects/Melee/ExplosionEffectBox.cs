using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectBox : MeleeEffectBox {

    //Damages enemies in an area
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            //Deal damage to enemy;
        }
    }
}
