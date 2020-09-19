using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public CharacterController characterController;
    public float gravity = -9.82f;
    public float jumpHeight = 3f;
    public float speed = 3f;
    public Vector3 velocity;

    public float mouseSensitivity = 100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject playerCamera;

    public GameObject UI;

    private bool isGrounded;
    private float xRotation = 0f;
    private bool locked = false;

    private void Start() {
        Instantiate(UI, transform);
        velocity = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
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
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 5, Color.red, 2);
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5, LayerMask.GetMask("Turret"))) {
            Debug.Log("Raycast hit turret: " + hit.collider.name);
        } else if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward*5, out hit, 5, LayerMask.GetMask("Tile"))) {
            Debug.Log("Raycast hit tile: " + hit.collider.name);
        }
    }

    private void MouseMovement() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    private void PlayerMovement() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f * Time.deltaTime;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //if(Input.GetButtonDown("Jump") && isGrounded) {
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        if(velocity.y > 0) { Debug.Log(velocity); }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity);
    }
}
