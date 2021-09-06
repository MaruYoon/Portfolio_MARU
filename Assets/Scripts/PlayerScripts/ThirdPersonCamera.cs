using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameObject Target;
    private Camera MainCamera;
    private Vector3 Offset;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float sensitivityX = 20.0f;
    private float sensitivityY = 20.0f;


    private void Awake()
    {
        Target = GameObject.Find("Player");
        MainCamera = Camera.main;
    }


    private void Start()
    {
        //camTransform = transform;
        this.transform.parent = Target.transform;
        Offset = new Vector3(0.0f, 0.8f, -0.8f);


        this.transform.position = new Vector3(
            Offset.x + Target.transform.position.x,
            Offset.y + Target.transform.position.y,
            Offset.z + Target.transform.position.z);


        this.transform.rotation = Quaternion.LookRotation((Target.transform.position - this.transform.position).normalized);
    }

    private void Update()
    {
        this.transform.position = Offset + Target.transform.position;

        /*
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
         */

        

    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
