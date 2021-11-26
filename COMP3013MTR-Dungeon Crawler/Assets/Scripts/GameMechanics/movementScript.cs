using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    CharacterController charController;
    Vector3 moveDir = Vector3.zero;
    float rotationX = 0;
    [Header("Camera")]
    public Camera playerCam;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public bool sprintActive = false;

    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        walkSpeed = 5f;
        runSpeed = 8f;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        if(Input.GetButtonDown("Sprint"))
        {
            SprintHold();
        }

        else if(Input.GetButtonUp("Sprint"))
        {
            SprintRelease();
        }

        float speedX = canMove ? (sprintActive ? runSpeed : walkSpeed) * Input.GetAxis("Vertical"):0;
        float speedY = canMove ? (sprintActive ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal"):0;

        moveDir = (forward * speedX) + (right * speedY);

        charController.Move(moveDir * Time.deltaTime);
        

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void SprintHold()
    {
        sprintActive = true;
        Debug.Log(Input.GetButtonDown("Sprint"));
    }

    void SprintRelease()
    {
        sprintActive = false;
        Debug.Log(Input.GetButtonDown("Sprint"));
    }
}
