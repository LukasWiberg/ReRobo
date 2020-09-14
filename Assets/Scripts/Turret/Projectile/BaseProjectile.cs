using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {
    public GameObject target;
    public float speed;
    public float damage;

    private void FixedUpdate() {
        if(!target) {
            Destroy(gameObject);
            return;
        }
        
        transform.LookAt(target.transform);
        Vector3 delta = target.transform.position - transform.position;
        if(delta.magnitude>speed) {
            delta = delta.normalized * speed;
        }
        transform.position +=  delta;
    }

    private void OnCollisionEnter(Collision collision) {
        collision.gameObject.GetComponent<BaseEnemy>().Damage(damage);
        Destroy(gameObject);
    }
}
