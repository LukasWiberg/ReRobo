using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBarrel : MonoBehaviour {
    public Animator[] shootAnimators;
    public string[] shootAnimtorKeys;
    public ParticleSystem[] shootParticles;

    public GameObject nozzle;
    public GameObject projectile { get; set; }

    public float animationSpeed;
    public float damage;
    public float projectileSpeed;
    public Vector3 projectileScale;


    void Start() {
        for(int i = 0; i < shootAnimators.Length; i++) {
            shootAnimators[i].speed = animationSpeed;
        }
    }

    public void Shoot(GameObject target) { 
        GameObject go = Instantiate(projectile, nozzle.transform.position, nozzle.transform.rotation);
        BaseProjectile projectileBase = go.GetComponent<BaseProjectile>();
        projectileBase.target = target;
        projectileBase.damage = damage;
        projectileBase.speed = projectileSpeed;
        projectile.transform.localScale = projectileScale;


        for(int i = 0; i<shootParticles.Length; i++) {
            shootParticles[i].Play();
        }

        for(int i = 0; i<shootAnimators.Length; i++) {
            shootAnimators[i].Play(shootAnimtorKeys[i]);
        }
    }
}
