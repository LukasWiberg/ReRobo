using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ReTD.Enums;

public class BaseEnemy : MonoBehaviour {
    public NavMeshAgent agent;
    public ReGrid reGrid;

    void Start() {
        agent.SetDestination(reGrid.defenseBase.transform.position);
    }
}
