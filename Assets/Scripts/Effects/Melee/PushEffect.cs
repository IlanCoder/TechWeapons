using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEffect : MeleeEffect {

    public override void SpawnEffectBox() {
        effectBox = Resources.Load("Push Effect Box") as GameObject;
        base.SpawnEffectBox();
    }

    public override void SetData() {
        base.SetData();
        effectBox.transform.localScale = new Vector3(effectSize, 1, 1);
        effectBox.GetComponent<PushEffectBox>().damage = damage;
    }

    override public void ActivateEffect() {
        base.ActivateEffect();
        effectBox.GetComponent<PushEffectBox>().Activate();
    }
}
