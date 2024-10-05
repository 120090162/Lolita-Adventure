using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    CharacterController playerController;

    Vector3 direction;

    public float speed = 1;
    public float jumpPower = 5;
    public float gravity = 7f;

    public float mousespeed = 5f;


    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    public float RotationY = 0f;
    public float RotationX = 0f;

    public Transform agretctCamera;


    // Use this for initialization
    void Start()
    {
        playerController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
        }
        direction.y -= gravity * Time.deltaTime;
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;

        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);
    
        this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);

    }
}
