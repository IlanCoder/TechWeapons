using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MeleeEffect {

    public override void SpawnEffectBox() {
        effectBox = Resources.Load("Explosion Effect Box") as GameObject;
        base.SpawnEffectBox(); 
    }

    public override void SetData() {
        base.SetData();
        effectBox.transform.localScale = new Vector3(effectSize, 1, effectSize);
        effectBox.GetComponent<ExplosionEffectBox>().damage = damage;
    }

    override public void ActivateEffect() {
        base.ActivateEffect();
        effectBox.GetComponent<ExplosionEffectBox>().Activate();
    }
}
