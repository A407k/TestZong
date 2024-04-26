using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public Camera playerCamera;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Player Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        // Limit vertical rotation to prevent flipping
        float currentRotationX = playerCamera.transform.rotation.eulerAngles.x;
        float desiredRotationX = currentRotationX - mouseY;

        if (desiredRotationX > 180)
        {
            desiredRotationX -= 360;
        }

        desiredRotationX = Mathf.Clamp(desiredRotationX, -90, 90);

        playerCamera.transform.localRotation = Quaternion.Euler(desiredRotationX, 0f, 0f);

        // Interaction with objects
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the desired input for interaction
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity))
            {
                // Check if the object is interactable (you can customize this logic based on your game)
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
