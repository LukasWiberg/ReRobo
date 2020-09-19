using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretUIScript : MonoBehaviour {
    public InteractableUI interactableUI;
    private TurretTile turret;
    private int index = -2, nextIndex;
    private TurretManager turretManager;


    private void Start() {
        turret = Helpers.GetTypeInParents<TurretTile>(interactableUI.target.transform);
        UpdateText();
    }

    public void Invoke() {
        if(nextIndex >= turretManager.turrets.Length) {
            index = -1;
            turret.SetTurret(null);
        } else {
            GameObject nextTurret = turretManager.turrets[nextIndex];
            index = nextIndex;
            turret.SetTurret(nextTurret);
            turret.turretIndex = index;
        }
        UpdateText();
    }

    private void UpdateText() {
        if(index == -2) {
            index = turret.turretIndex;
        }
        if(!turretManager) {
            turretManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurretManager>();
        }
        nextIndex = index + 1;

        if(nextIndex >= turretManager.turrets.Length) {
            interactableUI.text.text = "Remove turret";
        } else {
            GameObject nextTurret = turretManager.turrets[nextIndex];
            interactableUI.text.text = "Change to: " + nextTurret.name;
        }
    }
}
