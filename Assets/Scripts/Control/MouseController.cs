using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    private GameObject selectedTile;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, LayerMask.GetMask("Tile"))) {
                selectedTile = hit.collider.gameObject;
            }
        }
    }
}