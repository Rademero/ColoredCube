using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    //introuduces the rays
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;
    //sets up the list of rays for each side
    private List<GameObject> frontRays =new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();
   
    CubeState cubeState;
    CubeMap cubeMap;//gets the cube map
    public GameObject emptyGO;

    // Start is called before the first frame update
    void Start()
    {
        SetRayTransfprms();//starts the rays
        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();
    }

    // Update is called once per frame
    void Update()
    {
       // ReadState();
    }

    public void ReadState()
    {
        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();
        //gets the color of each side
        cubeState.up = ReadFace(upRays, tUp);
        cubeState.down = ReadFace(downRays, tDown);
        cubeState.left = ReadFace(leftRays, tLeft);
        cubeState.right = ReadFace(rightRays, tRight);
        cubeState.front = ReadFace(frontRays, tFront);
        cubeState.back = ReadFace(backRays, tBack);

        cubeMap.Set();
    }

    void SetRayTransfprms()
    {
        //sets the ray's direction as well as making new rays
        upRays = BuildRays(tUp, new Vector3(90, 90, 0));
        downRays = BuildRays(tDown, new Vector3(270, 90, 0));
        leftRays = BuildRays(tLeft, new Vector3(0, 90, 0));
        rightRays = BuildRays(tRight, new Vector3(0, 270, 0));
        frontRays = BuildRays(tFront, new Vector3(0, 0, 90));
        backRays = BuildRays(tBack, new Vector3(0, 180, 0));

    }

    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction)
    {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();//holds all of the rays
        //sets the rays positons as well as makes an ray for each pieace of a side
        for (int y =1; y > -2; y--)
        {
            for(int x = 1; x > -2; x--)
            {
                Vector3 startPos = new Vector3(rayTransform.localPosition.x + x,
                    rayTransform.localPosition.y + y, 
                    rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGO, startPos, Quaternion.identity, rayTransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    public List<GameObject>  ReadFace(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        foreach(GameObject rayStart in rayStarts)
        {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;
            //hit cube debug
            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);//adds to list to check color
                //print(hit.collider.gameObject.name);
            }
            else//not hitting the cube
            {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }

        return facesHit;
    }
}
