using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController charController;
    Vector3 moveDir = Vector3.zero;
    float rotationX = 0;
    [Header("Camera")]
    public Camera playerCam;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

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
        moveSpeed = 6f;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        moveDir = (forward * Input.GetAxis("Vertical")  + right * Input.GetAxis("Horizontal"));
    
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        charController.Move((moveDir * moveSpeed) * Time.deltaTime);

       


    }
}
