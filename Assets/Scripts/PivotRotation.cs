using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    Vector3 mouseRef;
    private bool dragging = false;
    private bool autoRotating = false;
    private float sensititvity = 0.4f;
    private float speed = 300f;
    private Vector3 rotation;
    private Quaternion targetQuaternion;
    private ReadCube readCube;
    private CubeState cubeState;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (dragging)
        {
            SpinSide(activeSide);
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
                RotateToRightAngle();
            }
        }
        if(activeSide == cubeState.front)
        {
            print("did it");
            transform.position.Set((float) -55.60972, (float) 34.126, (float) -2.573);
        }
        if (autoRotating)
        {
           AutoRotate();
        }
    }

    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - mouseRef);

        if (side == cubeState.front) {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Vector3.zero, Vector3.forward, rotation.z);
            transform.position.Set((float)-55.60972, (float)34.126, (float)-2.573);
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
        }
        if (side == cubeState.back)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Vector3.zero, Vector3.forward, rotation.z);
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
        }
        if (side == cubeState.left)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
        }
        if (side == cubeState.right)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
        }
        

      //  transform.Rotate(rotation, Space.Self);

        mouseRef = Input.mousePosition;
    }

    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;
      // localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }

    public void RotateToRightAngle()
    {
        Vector3 vector = transform.localEulerAngles;

        vector.x = Mathf.Round(vector.x / 90) * 90;
        vector.y = Mathf.Round(vector.y / 90) * 90;
        vector.z = Mathf.Round(vector.z / 90) * 90;

        targetQuaternion.eulerAngles = vector;
        autoRotating = true;
    }

    public void AutoRotate()
    {
        dragging = false;
        var step = speed * Time.deltaTime;
        // transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);

        //auto rotation for z rotation 
        if (transform.rotation.z > 0)
        {
           
            if (transform.rotation.z > 0.50 && transform.rotation.z < 1)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, 1);
                transform.position.Set((float)-55.60972, (float)34.126, (float)-2.573);
            }
            if(transform.rotation.z < .5 && transform.rotation.z > 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -1);
                transform.position.Set((float)-55.60972, (float)34.126, (float)-2.573);
            }
            
        }
        else
        {
            if (transform.rotation.z < -0.40 && transform.rotation.z > -1)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -1);
                transform.position.Set((float)-55.60972, (float)34.126, (float)-2.573);
            }
            if (transform.rotation.z > -.40 && transform.rotation.z < 0)
            {

                transform.RotateAround(Vector3.zero, Vector3.forward, 1);
                transform.position.Set((float)-55.60972, (float)34.126, (float)-2.573);
            }
        }
       

        if (Quaternion.Angle(transform.localRotation,targetQuaternion) <= 1)
        {
            transform.localRotation = targetQuaternion;
            cubeState.putDown(activeSide, transform.parent);
            readCube.ReadState();
            autoRotating = false;
            dragging = false;

        }
    }
}
