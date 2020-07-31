using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public enum State {
        OffHand,
        Idle,
        Attack
    }

    public int attackSpeed;
    public float damage;
    public string effectName;
    public int effectCharge;
    public int level;
    public int attSpdUpgrade;
    public float damageUpgrade;
    MeleeEffect effect;

    int currentCharge;
    State state;
    float currentAttackTime;
    float maxAttackTime;

    public void Set() {
        state = State.Idle;
        currentAttackTime = 0;
        currentCharge = 0;
        maxAttackTime = 60 / (float)attackSpeed;       
        AttatchEffect();
        SetModel();
        SetCollider();
    }

    void SetModel() {
        GameObject objectModel = Resources.Load<GameObject>(name);
        GetComponent<MeshFilter>().mesh = objectModel.GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().material = objectModel.GetComponent<MeshRenderer>().sharedMaterial;    
    }

    void SetCollider() {
        MeshCollider col = gameObject.AddComponent<MeshCollider>();
        col.enabled = false;
        col.convex = true;
        col.isTrigger = true;
    }

    void OffHandState() { }

    void IdleState() {
        if (Input.GetButtonDown("Fire1")) {
            GetComponent<MeshCollider>().enabled = true;
            state = State.Attack;
        }else if (Input.GetButtonDown("Fire2")) {
            LevelUp();
        }
    }

    void AttackState() {
        Move();
        if (currentCharge >= effectCharge) {
            ActivateEffect();          
        }
        if (currentAttackTime >= maxAttackTime) {
            currentAttackTime = 0;
            GetComponent<MeshCollider>().enabled = false;
            state = State.Idle;
        }
    }  

    void LevelUp() {
        attackSpeed += attSpdUpgrade;
        damage += damageUpgrade;
        maxAttackTime = 60 / (float)attackSpeed;
        ++level;
    }

    void ActivateEffect() {
        effect.ActivateEffect();
        currentCharge = 0;
    }

    void Update() {
        switch (state) {
            case State.OffHand:
                OffHandState();
                break;
            case State.Idle:
                IdleState();
                break;
            case State.Attack:
                AttackState();    
                break;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            ++currentCharge;
        }
    }

    void AttatchEffect() {
        if (effectName == "Push") {
            effect = gameObject.AddComponent<PushEffect>();
        }else if(effectName == "Explosion") {
            effect = gameObject.AddComponent<ExplosionEffect>();            
        }
        effect.Load(LoaderManager.LoadMeleeEffect(effectName));
        effect.SpawnEffectBox();
    }

    //Delete once attack animation is made---------
    void Move() {
        currentAttackTime += Time.deltaTime;
        float attackMove = currentAttackTime * 6 / maxAttackTime;
        transform.position = new Vector3(Mathf.Cos(attackMove) * 3, transform.position.y, transform.position.z);
    }
    //----------------------------------------------
}
