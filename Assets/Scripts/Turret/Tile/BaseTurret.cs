using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour {
    public float damage;
    public float attackSpeed;
    public float projectileSpeed;
    public float range;
    public GameObject projectile;
    public GameObject nuzzle;
    public ParticleSystem muzzleSmokeParticles;
    public ParticleSystem muzzleExplosionParticles;

    private Animator muzzleAnimator;
    private GameObject target;
    private float lastProjectile;

    private void Awake() {
        muzzleAnimator = nuzzle.transform.parent.GetComponent<Animator>();
    }

    private void Update() {
        if(target) {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        }
    }

    private void FixedUpdate() {
        lastProjectile += Time.fixedDeltaTime;
        if(lastProjectile > 60/attackSpeed) {
            if(TargetInRange(target)) {
                Shoot(target);
            }
        }
    }


    private bool TargetInRange(GameObject target) {
        if(target) {
            Vector3 delta = (transform.position - target.transform.position);
            delta = new Vector3(delta.x, 0, delta.y);
            if(delta.magnitude < range) {
                return true;
            } else {
                target = null;
                GetNewTarget();
            }
        } else {
            GetNewTarget();
        }

        if(target) {
            return true;
        } else {
            return false;
        }
    }

    private void GetNewTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i++) {
            Vector3 delta = (transform.position - enemies[i].transform.position);
            delta = new Vector3(delta.x, 0, delta.y);
            if(delta.magnitude < range) {
                target = enemies[i];
            }
        }
    }

    private void Shoot(GameObject target) {
        lastProjectile = lastProjectile % (60/attackSpeed);
        GameObject go = Instantiate(projectile, nuzzle.transform.position, nuzzle.transform.rotation);
        BaseProjectile projectileBase = go.GetComponent<BaseProjectile>();
        projectileBase.target = target;
        projectileBase.damage = damage;
        projectileBase.speed = projectileSpeed;

        muzzleExplosionParticles.Play();
        muzzleSmokeParticles.Play();
        muzzleAnimator.Play("Muzzle");
    }
}
