using ReTD.Helpers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextFindMain : MonoBehaviour {
    void Awake() {
        Helpers.GetGameManager().textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }
}
