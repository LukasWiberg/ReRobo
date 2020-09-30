using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int health = 10;
    public PlayerController playerController;
    public TextMeshProUGUI textMeshPro { get; set; }

    public void Update() {
        textMeshPro.text = "Lives: " + health;
    }

    public void HideUI(GameObject ui) {
        playerController.LockControlls();
        Destroy(ui);
    }

    public void ShowUI(GameObject ui, Transform parent) {
        playerController.UnlockControlls();
        Instantiate(ui, parent);
    }
}