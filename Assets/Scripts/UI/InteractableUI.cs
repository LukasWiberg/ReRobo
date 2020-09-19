using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractableUI : MonoBehaviour {
    public GameObject target;
    public TextMeshProUGUI text;
    public UnityEvent targetEvent;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }
    public void Interact() {
        targetEvent.Invoke();
    }
}
