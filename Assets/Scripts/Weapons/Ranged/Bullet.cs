using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector3 direction;    
    public bool inUse;
    RangedEffect effect;
    float maxDistance;
    float speed;
    float currDistance;
    
    void Start() {
        speed = 0.2f;
        Deactivate();
    }

    void Update() {
        transform.position += direction * speed;
        currDistance += speed;
        if (currDistance >= maxDistance) {
            Deactivate();
        }
    }

    public void SetStaticData(float distance, RangedEffect eff) {
        maxDistance = distance;
        effect = eff;
    }

    public void Activate() {
        inUse = true;
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        inUse = false;
        gameObject.SetActive(false);
        currDistance = 0;
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            effect.ActivateEffect(col.gameObject);
            Deactivate();
        }
    }
}
