using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour {
    public float damage;
    public float attackSpeed;
    public float projectileSpeed;
    public float range;
    public TurretBarrel[] barrels;
    public float animationSpeed = 1;
    public Vector3 projectileScale = Vector3.one;
    public GameObject projectile;


    private int nextBarrel = 0;
    private GameObject target;
    private float lastProjectile;

    private void Awake() {
        for(int i = 0; i < barrels.Length; i++) {
            barrels[i].damage = damage;
            barrels[i].projectileSpeed = projectileSpeed;
            barrels[i].animationSpeed = animationSpeed;
            barrels[i].projectileScale = projectileScale;
            barrels[i].projectile = projectile;
        }
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
            float delta = Vector3.Distance(transform.position, enemies[i].transform.position);
            if(delta < range) {
                target = enemies[i].transform.GetChild(0).gameObject;
            }
        }
    }

    private void Shoot(GameObject target) {
        lastProjectile = lastProjectile % (60/attackSpeed);
        barrels[nextBarrel].Shoot(target);

        nextBarrel++;
        
        if(nextBarrel>=barrels.Length) {
            nextBarrel = 0;
        }
    }
}
