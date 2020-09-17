using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class SpawnableParticles : MonoBehaviour {
    ParticleSystem ps;
    void Start() {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
        StartCoroutine(deathWait());
    }

    private IEnumerator deathWait() {
        yield return new WaitForSeconds(ps.main.duration);
        Destroy(gameObject);
    }
}
