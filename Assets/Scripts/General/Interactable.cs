using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
    public UnityEvent targetEvent;

    public void Interact() {
        targetEvent.Invoke();
    }
}
