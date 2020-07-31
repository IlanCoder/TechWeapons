using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour {

    public enum State {
        OffHand,
        Idle,
        Fired,
        Reload
    }

    public int attackSpeed;
    public float range;
    public int damage;
    public float reloadSpeed;
    public int ammo;
    public float effectDamage;
    public float effectEfficiency;
    public string effectName;
    public int level;
    public GameObject[] bulletMagazine;
    RangedEffect effect;

    State state;   
    float currentFireInterval;
    float maxFireInterval;
    int ammoLeft;
    float reloadTime;

    public virtual void Set() {
        state = State.Idle;
        currentFireInterval = 0;
        ammoLeft = ammo;
        reloadTime = 0;
        AttatchEffect();
        SetMagazine();
        maxFireInterval = 60 / (float)attackSpeed;      
    }

    public virtual void SetMagazine() {
        for (int currBullet = 0; currBullet < bulletMagazine.Length; ++currBullet) {
            bulletMagazine[currBullet] = Resources.Load<GameObject>("Bullet");
            bulletMagazine[currBullet] = Instantiate(bulletMagazine[currBullet]);           
            bulletMagazine[currBullet].GetComponent<Bullet>().SetStaticData(range, effect);
        }
    }

    void OffHandState() { }

    void IdleState() {
        if (Input.GetButton("Fire1")) {
            if (ammoLeft <= 0) {
                state = State.Reload;
                return;
            }
            Shoot();           
            --ammoLeft;
            state = State.Fired;
        } else if (Input.GetButtonDown("Fire2")) {
            LevelUp();
        }
    }

    void FiredState() {
        currentFireInterval += Time.deltaTime;
        if (currentFireInterval >= maxFireInterval) {
            currentFireInterval = 0;
            state = State.Idle;
        }
    }

    void ReloadState() {
        reloadTime += Time.deltaTime;
        if (reloadTime >= reloadSpeed) {
            reloadTime = 0;
            ammoLeft = ammo;
            state = State.Idle;
        }
    }

    public virtual void LevelUp() {
        ++level;
    }

    void Update() {
        switch (state) {
            case State.OffHand:
                OffHandState();
                break;
            case State.Idle:
                IdleState();
                break;
            case State.Fired:
                FiredState();
                break;
            case State.Reload:
                ReloadState();
                break;
        }
    }

    public virtual void ReadyBullet(Bullet bullet, int magazineLocation) {
        Vector3 tempTarget = transform.GetChild(0).position - gameObject.transform.position;
        tempTarget.Normalize();
        bullet.direction = tempTarget;
        bulletMagazine[magazineLocation].transform.position = transform.position;
        bulletMagazine[magazineLocation].transform.rotation = transform.rotation;
    }

    public virtual void Shoot() {
        for (int currentBullet = 0; currentBullet < bulletMagazine.Length; ++currentBullet) {
            Bullet bullet = bulletMagazine[currentBullet].GetComponent<Bullet>();
            if (!bullet.inUse) {
                ReadyBullet(bullet, currentBullet);
                bullet.Activate();
                return;
            }
        }
    }

    void AttatchEffect() {
        effect = gameObject.AddComponent<RangedEffect>();
        effect.Load(LoaderManager.LoadRangeEffect(effectName));
    }
}
