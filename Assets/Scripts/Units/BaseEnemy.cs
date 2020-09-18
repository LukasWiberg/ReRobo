using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ReTD.Enums;

public class BaseEnemy : MonoBehaviour {
    public NavMeshAgent agent;
    public ReGrid reGrid;
    public float maxHealth = 100;
    public float health { get; private set; }
    public float speed = 10;

    void Start() {
        health = maxHealth;
        agent.SetDestination(reGrid.defenseBase.transform.position);
        agent.speed = speed;
    }

    public void Damage(float damage) {
        health -= damage;
        if(health<=0) {
            Die();
        }
    }

    public void Die(bool destroyed = true) {
        if(destroyed) {
            //TODO fancy animation or something;
        }

        Destroy(gameObject);
    }
}
