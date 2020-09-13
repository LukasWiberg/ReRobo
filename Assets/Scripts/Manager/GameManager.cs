using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int health = 10;
    public TextMeshProUGUI textMeshPro;

    public void Update() {
        textMeshPro.text = "Lives: " + health;
    }
}
