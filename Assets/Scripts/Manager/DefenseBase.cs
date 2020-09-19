using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBase : MonoBehaviour {
    private GameManager gameManager; 
    
    void Awake() {
        gameManager = Helpers.GetGameManager();
    }

    void Update() {
        
    }
    

    void OnCollisionEnter(Collision collision) {
        gameManager.health -= 1;
        collision.gameObject.GetComponent<BaseEnemy>().Die(false);
    }
}
