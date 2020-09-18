using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile: BaseProjectile {
    public GameObject deathParticles;
    private new void OnCollisionEnter(Collision collision) {
        Instantiate(deathParticles, transform.position, transform.rotation);
        base.OnCollisionEnter(collision);
    }
}
