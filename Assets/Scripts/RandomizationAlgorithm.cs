using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizationAlgorithm : MonoBehaviour
{
    // The number of moves it does for randomization of the cube.
    private int maxMoves = 1;
    // Counter used for the rotations.
    private int numMoves = 0;

    Vector3 mouse;

    private PivotRotation pivot;
    // Down
    public PivotRotation pivotD;
    // Front
    public PivotRotation pivotF;
    // Up
    public PivotRotation pivotU;
    // Right
    public PivotRotation pivotR;
    // Left
    public PivotRotation pivotL;
    // Back
    public PivotRotation pivotB;

    public Transform trueCenter;

    List<GameObject> activeSide;
    private CubeState cubeState;
    private SelectFace select;

    private bool previousRotationDone;
    private bool autoRotate;

    void Start()
    {
        pivot = FindObjectOfType<PivotRotation>();
        cubeState = FindObjectOfType<CubeState>();
        select = FindObjectOfType<SelectFace>();
        previousRotationDone = true;
        autoRotate = false;
    }


    void Update()
    {
        if (numMoves < maxMoves)
        {
            if(previousRotationDone)
            {
                previousRotationDone = false;
                choosePivot();
                chooseCommand();
                numMoves = numMoves + 1;
            }
    
        }

        // Used for testing purposes 
        if (Input.GetKey("z"))
        {
            if (previousRotationDone)
            {
                previousRotationDone = false;
                choosePivot();
                chooseCommand();
            }
        }


    }

    // When choosing the pivot the activeSide has to be set as well because each pivot
    // is associated with one of the sides.
    void choosePivot()
    {
        float ran = Random.Range(0.0f, 6.0f);
        ran = 4.9f;

        // Front side
        if (ran > 5.0f)
        {
            pivot = pivotF;
            activeSide = cubeState.front;
        }
        // Up side
        if (ran <= 5.0f && ran > 4.0f)
        {
            pivot = pivotU;
            activeSide = cubeState.up;
        }
        // Back side
        if (ran <= 4.0f && ran > 3.0f)
        {
            pivot = pivotB;
            activeSide = cubeState.back;

        }
        // Down side
        if (ran <= 3.0f && ran > 2.0f)
        {
            pivot = pivotD;
            activeSide = cubeState.down;
        }
        // Left side
        if (ran <= 2.0f && ran > 1.0f)
        {
            pivot = pivotL;
            activeSide = cubeState.left;

        }
        // Right side
        if (ran <= 1.0f)
        {
            pivot = pivotR;
            activeSide = cubeState.right;
        }
    }


    // Chooses how to rotate the cube.
    void chooseCommand()
    {

        mouse = Vector3.zero;

        // Making sure the entire side is recognized via select face script.
        Vector3 centerPos = pivot.getCenter();
        Vector3 dir = trueCenter.position;
        select.randomUpdate(centerPos, dir);

        //print(centerPos);
        //print(dir);

        float num = Random.Range(0.0f, 1.0f);

        // Can only rotate a side in two directions
        if (num < 0.5)
        {
            mouse.Set(-20, -20, 0);
        }
        else if(num >= 0.5)
        {
            mouse.Set(20, 20, 0);
        }

        pivot.randomRotate(activeSide, mouse);

        pivot.RotateToRightAngle();
        autoRotate = pivot.getAutoRotate();
        if(autoRotate)
        {
            pivot.AutoRotate();
        }
        wait();

        previousRotationDone = true;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);
    }
}
