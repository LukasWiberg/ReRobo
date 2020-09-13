using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBase : MonoBehaviour {
    private GameManager defenseBase; 
    
    void Awake() {
        defenseBase = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnCollisionEnter(Collision collision) {
        defenseBase.health -= 1;
        Destroy(collision.transform.gameObject);
    }
}
