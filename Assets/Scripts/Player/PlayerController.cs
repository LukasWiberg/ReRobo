using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using ReTD.UI;
using ReTD.Helpers;

public class PlayerController : MonoBehaviour {
    [Header("Player Stats")]
    public CharacterController characterController;
    public float gravity = 9.82f;
    public float speed = 3f;


    [Header("Player Preferences")]
    public float mouseSensitivity = 2f;


    [Header("Refernces")]
    public Transform groundCheck;
    public GameObject playerCamera;


    [Header("UI Components")]
    public GameObject UI;
    public GameObject turretUI;
    public GameObject tileUI;
    public GameObject genericInteractableUI;

    private bool locked = false;
    private GameObject target;
    private InteractableUI activeUI;
    private float verticalSpeed = 0;

    private int turretUILayer, tileLayer;

    private void Start() {
        Instantiate(UI, transform);
        Cursor.lockState = CursorLockMode.Locked;
        turretUILayer = LayerMask.NameToLayer("TurretUI");
        tileLayer = LayerMask.NameToLayer("Tile");
    }

    public void UnlockControlls() {
        locked = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LockControlls() {
        locked = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if(!locked) {
            PlayerMovement();
            MouseMovement();
            Raycast();
        }
    }

    private void Raycast() {
        RaycastHit hit;

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 1f, LayerMask.GetMask(new string[] { "TurretUI", "Tile", "Default" }))) {
            if(hit.collider.gameObject != target) {
                if(activeUI) {
                    Destroy(activeUI.gameObject);
                }
                target = hit.collider.gameObject;
                switch(target.layer) {
                    case (int) Layer.Tile: 
                        activeUI = Instantiate(tileUI, transform).GetComponent<InteractableUI>();
                        break;
                    case (int) Layer.TurretUI:
                        activeUI = Instantiate(turretUI, transform).GetComponent<InteractableUI>();
                        break;
                }

                if(!activeUI) {
                    if(target.tag == "Player") {
                        activeUI = Instantiate(genericInteractableUI, transform).GetComponent<InteractableUI>();
                        activeUI.SetText(Helpers.GetTypeInParents<GenericUIText>(target.transform).text);
                    }
                }

                activeUI.target = target;
            }
        } else {
            target = null;
            if(activeUI) {
                Destroy(activeUI.gameObject);
            }
        }
    }

    private void MouseMovement() {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        playerCamera.transform.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = playerCamera.transform.localEulerAngles;
        if(currentRotation.x > 180)
            currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(currentRotation);

    }

    private void PlayerMovement() {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if(characterController.isGrounded)
            verticalSpeed = 0;
        else
            verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }
}
