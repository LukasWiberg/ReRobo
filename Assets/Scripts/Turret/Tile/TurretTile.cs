using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretTile : MonoBehaviour {
    public GameObject turret;
    public Transform turretBase;
    public TurretVision turretVision;
    public int turretIndex = -1;

    public void SetTurretReference(GameObject turret) {
        this.turret = turret;
        turretVision.turret = this.turret.GetComponent<BaseTurret>();
    }

    public void SetTurret(GameObject turret) {
#if UNITY_EDITOR
        DestroyImmediate(this.turret);
#else
        Destroy(this.turret);
#endif
        if(turret) {
            this.turret = Instantiate(turret, turretBase.position, Quaternion.Euler(0, 0, 0), turretBase);
            turretVision.turret = this.turret.GetComponent<BaseTurret>();
        }
    }
}


#if UNITY_EDITOR

[CustomEditor(typeof(TurretTile))]
public class TurretTileEditor : Editor {
    private int index = -1;
    private TurretManager turretManager;
    private TurretTile turretTile;

    public void Awake() {
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(!turretManager) {
            turretManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurretManager>();
        }
        if(!turretTile) {
            turretTile = (TurretTile) target;
            foreach(Transform child in turretTile.turretBase) {
                if(child.tag == "Turret") {
                    turretTile.SetTurretReference(child.gameObject);
                }
            }
            index = turretTile.turretIndex;
        }

        if(turretManager.turrets.Length<1) {
            GUILayout.Label("No turrets");
            return;
        }

        int nextIndex = index + 1;

        if(nextIndex >= turretManager.turrets.Length) {
            if(GUILayout.Button("Remove turret")) {
                index = -1;
                turretTile.SetTurret(null);
            }
        } else {
            GameObject nextTurret = turretManager.turrets[nextIndex];
            if(GUILayout.Button("Change to: " + nextTurret.name)) {
                index = nextIndex;
                turretTile.SetTurret(nextTurret);
                turretTile.turretIndex = index;
            }
        }
    }
}
#endif