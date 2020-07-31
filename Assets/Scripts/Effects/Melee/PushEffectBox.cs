using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEffectBox : MeleeEffectBox {
    
    void PushEnemy(Collider enemy) {
        Vector3 pushDir = enemy.transform.position - transform.position;
        pushDir.Normalize();
        pushDir *= 10;
        enemy.GetComponent<Rigidbody>().AddForce(pushDir, ForceMode.Impulse);
    }

    //Pushes enemies with certain force
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            PushEnemy(col);
            //Deal damage to enemy;
        }
    }
}
