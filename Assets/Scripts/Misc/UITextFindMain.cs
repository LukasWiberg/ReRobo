using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextFindMain : MonoBehaviour {
    void Awake() {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }
}
