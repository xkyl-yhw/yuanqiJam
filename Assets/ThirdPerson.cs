using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public float freeDistance = 5f;
    private Camera ThirdCam;
    public float rotateSpeed;
    public float upAngle = 80;
    public float moveSpeed=10f;

    private float rotDegree = 0;
    private float rollDegree = 30;
    private float rot, roll;
    private Vector3 moveDir;

    private void Start()
    {
        ThirdCam = Camera.main;
    }

    private void Update()
    {
        moveInput();
    }

    private void FixedUpdate()
    {
        playerMove();
        cameraRot();
    }

    private void playerMove()
    {
        transform.Translate(moveDir * Time.fixedDeltaTime * moveSpeed);
    }

    private void moveInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDir = v * Vector3.ProjectOnPlane(ThirdCam.transform.forward, transform.up) + h * Vector3.ProjectOnPlane(ThirdCam.transform.right, transform.up);
    }

    private void cameraRot()
    {
        float inputY = Input.GetAxis("Mouse Y");
        float inputX = Input.GetAxis("Mouse X");
        rotDegree -= inputX * rotateSpeed;
        rollDegree += inputY * rotateSpeed;
        rollDegree = Mathf.Clamp(rollDegree, -upAngle, upAngle);
        rot = rotDegree * Mathf.PI / 180;
        roll = rollDegree * Mathf.PI / 180;

        float d = freeDistance * Mathf.Cos(roll);
        float height = freeDistance * Mathf.Sin(roll);
        Vector3 cameraPos = Vector3.zero;

        cameraPos.x = transform.position.x + d * Mathf.Cos(rot);
        cameraPos.z = transform.position.z + d * Mathf.Sin(rot);
        cameraPos.y = transform.position.y + height;
        //Debug.Log(cameraPos);
        ThirdCam.transform.position = cameraPos;
        ThirdCam.transform.LookAt(this.transform.position);
    }
}
