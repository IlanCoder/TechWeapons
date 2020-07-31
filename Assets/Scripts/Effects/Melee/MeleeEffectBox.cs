using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEffectBox : MonoBehaviour {
    public float damage;
    float lifeTime;

    void Update() {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void Activate() {
        lifeTime = 0.5f;
        gameObject.SetActive(true);
    }
}
