using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed = 0.1f;
    void Update() {
        Vector3 delta = Vector3.zero;
        if(Input.GetKey(KeyCode.W)) {
            delta += new Vector3(0, 0, -1);
        }

        if(Input.GetKey(KeyCode.A)) {
            delta += new Vector3(1, 0, 0);
        }

        if(Input.GetKey(KeyCode.S)) {
            delta += new Vector3(0, 0, 1);
        }

        if(Input.GetKey(KeyCode.D)) {
            delta += new Vector3(-1, 0, 0);
        }
        if(delta != Vector3.zero) {
            //TODO make the camera move the same dsitance when going diagonally
            transform.position += delta.normalized * speed;
        }
    }
}
