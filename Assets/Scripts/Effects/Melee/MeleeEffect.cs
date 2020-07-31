using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEffect : MonoBehaviour {

    public GameObject effectBox;
    public int damage;
    public int area;
    public int effectSize;

    public void Load(XMLMeleeEffect effectData) {
        damage = effectData.damage;
        area = effectData.area;
    }

    public virtual void SpawnEffectBox() {
        effectBox = Instantiate(effectBox, transform.position, Quaternion.identity);
        SetData();
    }

    public virtual void SetData() {
        effectSize = area * 2 - 1;
    }

    public virtual void ActivateEffect() {
        effectBox.transform.position = transform.position;
    }
}
