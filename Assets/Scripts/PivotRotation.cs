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
    private float sensititvity = 2.5f;
    private float speed = 300f;
    private Vector3 rotation;
    private Quaternion targetQuaternion;
    private ReadCube readCube;
    private CubeState cubeState;
    public Transform Center;
    public Vector3 ogPositon = new Vector3();
    public int stuckCounter;
    private int forceAuto;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();

        if (activeSide == cubeState.front)
        {
            ogPositon.x = transform.position.x;
            ogPositon.y = transform.position.z;
            ogPositon.z = transform.position.z;
        }
    }

    // Update is called once per frame
    public void Update()
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
        if (autoRotating)
        {
           // stuckCounter = 0;
            AutoRotate();
        }
    }

    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - mouseRef);
        mouseOffset.Normalize();

        if (side == cubeState.front) {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.forward, rotation.z);
            transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.up, rotation.y);
        }
        if (side == cubeState.back)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Center.position, Vector3.forward, rotation.z);
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.up, rotation.y);

        }
        if (side == cubeState.left)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.right, rotation.x);
        }
        if (side == cubeState.right)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Center.position, Vector3.right, rotation.x);

        }
        stuckCounter = 0;

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
       // stuckCounter = 0;
    }

    public void AutoRotate()
    {
        dragging = false;
        var step = speed * Time.deltaTime;
        // transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);
        // Keeps the values of the x,y,z between -1 and 1
        transform.rotation.Normalize();
        //auto rotation for front and back
        if (transform.rotation.z > 0)
        {
           
            if (transform.rotation.z > 0.4500000000 && transform.rotation.z < 1.00)
            {
                transform.RotateAround(Center.position, Vector3.forward, 1);
            }
            if (transform.rotation.z < 0.4500000000 && transform.rotation.z > 0.00)
            {
                transform.RotateAround(Center.position, Vector3.forward, -1);
            }

        }
        else if (transform.rotation.z < 0)
        {
            if (transform.rotation.z < -0.45000000 && transform.rotation.z > -1.00)
            {
                transform.RotateAround(Center.position, Vector3.forward, -1);
            }
            if (transform.rotation.z > -0.45000000 && transform.rotation.z < 0.00)
            {

                transform.RotateAround(Center.position, Vector3.forward, 1);
            }
        }
        //Up and Down auto rotate
        if (transform.rotation.y > 0)
        {
            if (transform.rotation.y > 0.450000000 && transform.rotation.y < 1.00)
            {
                transform.RotateAround(Center.position, Vector3.up, 1);
            }
            if (transform.rotation.y < 0.450000000 && transform.rotation.y > 0.00)
            {
                transform.RotateAround(Center.position, Vector3.up, -1);
            }

        }
        else if (transform.rotation.y < 0)
        {
            if (transform.rotation.y < -0.45000000 && transform.rotation.y > -1.00)
            {
                transform.RotateAround(Center.position, Vector3.up, -1);
            }
            if (transform.rotation.y > -0.45000000 && transform.rotation.y < 0.00)
            {

                transform.RotateAround(Center.position, Vector3.up, 1);
            }
        }
        //Needs work x rotation for left and right side
        if (transform.rotation.x > 0)
        {

            if (transform.rotation.x > 0.45000000 && transform.rotation.x < 1.00)
            {
                transform.RotateAround(Center.position, Vector3.right, 1);
            }
            if (transform.rotation.x < 0.450000000 && transform.rotation.x > 0.00)
            {
                transform.RotateAround(Center.position, Vector3.right, -1);

            }

        }
        else if (transform.rotation.x < 0)
        {
            if (transform.rotation.x < -0.4500000000 && transform.rotation.x > -1.00)
            {
                transform.RotateAround(Center.position, Vector3.right, -1);
            }
            if (transform.rotation.x > -0.4500000000 && transform.rotation.x < 0.00)
            {
                transform.RotateAround(Center.position, Vector3.right, 1);
            }
        }
        stuckCounter++;
        if(stuckCounter >= 90)
        {
            if(activeSide == cubeState.up || activeSide == cubeState.down)
            {
                    transform.RotateAround(Center.position, Vector3.up, 5);
            }
            if (activeSide == cubeState.left || activeSide == cubeState.right)
            {
                transform.RotateAround(Center.position, Vector3.right, 5);
            }
            if (activeSide == cubeState.front || activeSide == cubeState.back)
            {
                    transform.RotateAround(Center.position, Vector3.forward, 5);
            }
        }

        print(stuckCounter);
        float angle = Quaternion.Angle(transform.localRotation, targetQuaternion);
        if (angle <= 1 || (angle <= 91.5 && angle >= 89.5))
        {
            //print("here");
            //transform.localRotation = targetQuaternion;
            cubeState.putDown(activeSide, transform.parent);
            readCube.ReadState();
            autoRotating = false;
            dragging = false;
            stuckCounter = 0;

        }
        temp();
       
    }

    IEnumerator temp()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void randomRotate(List<GameObject> side, Vector3 mouseOffset)
    {
        rotation = Vector3.zero;

        //print("Entered randomRotation in pivot.");
        //print(side);

        if (side == cubeState.front)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.forward, rotation.z);
            transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.up, rotation.y);
        }
        if (side == cubeState.back)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Center.position, Vector3.forward, rotation.z);
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Center.position, Vector3.up, rotation.y);
        }
        if (side == cubeState.left)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Center.position, Vector3.left, rotation.x);
        }
        if (side == cubeState.right)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Center.position, Vector3.left, rotation.x);

        }


        RotateToRightAngle();
        AutoRotate();
        //transform.RotateAround(Vector3.zero, Vector3.forward, 1);

    }

    public List<GameObject> getActiveSide()
    {
        return activeSide;
    }
}
