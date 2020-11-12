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
<<<<<<< HEAD
    public Transform Center;
=======
    public Vector3 ogPositon = new Vector3();
>>>>>>> 7e502e17759f64d14982b53d7676fbff63297a50
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
        if(activeSide == cubeState.front)
        { 
           // transform.position.Set(ogPositon.x,ogPositon.y,ogPositon.z);
            transform.position.Set(-55.60972f, 34.126f,-2.573f);
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
            transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Vector3.zero, Vector3.up, rotation.y);
        }
        if (side == cubeState.back)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Vector3.zero, Vector3.forward, rotation.z);
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
            transform.RotateAround(Vector3.zero, Vector3.up, rotation.y);
        }
        if (side == cubeState.left)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Vector3.zero, Vector3.left, rotation.x);
        }
        if (side == cubeState.right)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
            transform.RotateAround(Vector3.zero, Vector3.left, rotation.x);

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

        //auto rotation for front and back
        if (transform.rotation.z > 0)
        {
           
            if (transform.rotation.z >= 0.45 && transform.rotation.z < 1)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.z < 0.45 && transform.rotation.z > 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }

        }
        else if (transform.rotation.z < 0)
        {
            if (transform.rotation.z <= -0.45 && transform.rotation.z > -1)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.z > -0.45 && transform.rotation.z < 0)
            {

                transform.RotateAround(Vector3.zero, Vector3.forward, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
        }
        //Up and Down auto rotate
        if (transform.rotation.y > 0)
        {

            if (transform.rotation.y >= 0.45 && transform.rotation.y < 1)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.y < 0.45 && transform.rotation.y > 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }

        }
        else if (transform.rotation.y < 0)
        {
            if (transform.rotation.y <= -0.45 && transform.rotation.y > -1)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.y > -0.45 && transform.rotation.y < 0)
            {

                transform.RotateAround(Vector3.zero, Vector3.up, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
        }
        //Needs work x rotation for left and rifht side
        if (transform.rotation.x > 0)
        {

            if (transform.rotation.x >= 0.45 && transform.rotation.x < 1)
            {
                transform.RotateAround(Vector3.zero, Vector3.left, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.x < 0.45 && transform.rotation.x > 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.left, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }

        }
        else if (transform.rotation.x < 0)
        {
            if (transform.rotation.x <= -0.45 && transform.rotation.x > -1)
            {
                transform.RotateAround(Vector3.zero, Vector3.left, -1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
            }
            if (transform.rotation.x > -0.45 && transform.rotation.x < 0)
            {

                transform.RotateAround(Vector3.zero, Vector3.left, 1);
                transform.position.Set(ogPositon.x, ogPositon.y, ogPositon.z);
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

    public void randomRotate(List<GameObject> side, Vector3 mouseOffset)
    {
        rotation = Vector3.zero;

        print("Entered randomRotation in pivot.");
        print(side);

        if (side == cubeState.front)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensititvity * -1;
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
        }
        if (side == cubeState.back)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensititvity * 1;
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

        transform.RotateAround(Vector3.zero, Vector3.forward, 1);

    }

    public List<GameObject> getActiveSide()
    {
        return activeSide;
    }
}
