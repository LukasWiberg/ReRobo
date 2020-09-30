using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    private GameObject player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update() {
        transform.LookAt(player.transform);
    }
}
