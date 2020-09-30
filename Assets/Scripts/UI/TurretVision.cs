using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurretVision : MonoBehaviour {
    public BaseTurret turret;
    public TextMeshProUGUI title, attackspeed, damage, range, projectile, rotationSpeed, shootingAngle;



    private void Start() {
        UpdateTest();
    }

    public void UpdateTest() {
        if(turret) {
            title.text = turret.name;
            attackspeed.text = "RPM: " + turret.attackSpeed + "";
            damage.text = "Damage: " + turret.damage + "";
            range.text = "range: " + turret.range + "m";
            projectile.text = "" + turret.projectile.GetComponent<BaseProjectile>().name + "";
            rotationSpeed.text = "Rotation: " + turret.rotationSpeed + "°/sec";
            shootingAngle.text = "Shooting angle: " + turret.rotationSpeed + "°";
        }
    }
}
