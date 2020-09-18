using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {
    public GameObject target;
    public float speed = 1;
    public float damage = 1;

    public float shootAngle;
    public float rotationSpeed;

    private bool disabled = false;

    private void FixedUpdate() {
        if(!target) {
            Destroy(gameObject);
            return;
        }
        
        transform.LookAt(target.transform);

        Vector3 delta = target.transform.position - transform.position;
        if(delta.magnitude>speed) {
            delta = delta.normalized * speed;
            transform.position += delta;
        } else {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.position - target.transform.position, out hit);
            transform.position = hit.point;
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if(disabled) {
            return;
        }

        collision.gameObject.GetComponent<BaseEnemy>().Damage(damage);
        disabled = true;
        Destroy(gameObject);
    }
}
