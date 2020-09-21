using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBase : MonoBehaviour {
    private GameManager gameManager; 
    
    void Awake() {
        gameManager = Helpers.GetGameManager();
    }

    private void OnTriggerEnter(Collider other) {
        gameManager.health -= 1;
        Helpers.GetTypeInParents<BaseEnemy>(other.transform).Die(false);
    }
}
