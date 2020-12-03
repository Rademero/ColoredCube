using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizationAlgorithm : MonoBehaviour
{
    // The number of moves it does for randomization of the cube.
    private int maxMoves = 64;
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
    List<GameObject> activeSide;
    private CubeState cubeState;

    void Start()
    {
        pivot = FindObjectOfType<PivotRotation>();
        cubeState = FindObjectOfType<CubeState>();
    }


    void Update()
    {
        if (numMoves < maxMoves)
        {
            //chooseSide();
            //chooseCommand();
            numMoves = numMoves + 1;
        }

        // Used for testing purposes 
        if (Input.GetKey("z"))
        {
            chooseSide();
            chooseCommand();
        }


    }

    void chooseSide()
    {
        float ran = Random.Range(0.0f, 6.0f);

        // Front side
        if (ran > 5.0f)
        {
            activeSide = cubeState.front;
        }
        // Up side
        if (ran <= 5.0f && ran > 4.0f)
        {
            activeSide = cubeState.up;
        }
        // Back side
        if (ran <= 4.0f && ran > 3.0f)
        {
            activeSide = cubeState.back;
        }
        // Down side
        if (ran <= 3.0f && ran > 2.0f)
        {
            activeSide = cubeState.down;
        }
        // Left side
        if (ran <= 2.0f && ran > 1.0f)
        {
            activeSide = cubeState.left;

        }      
        // Right side
        if (ran <= 1.0f)
        {
            activeSide = cubeState.right;

        }

    }

    // Chooses how to rotate the cube.
    void chooseCommand()
    {

        float num = Random.Range(1.0f, 5.0f);

        mouse = Vector3.zero;

        // Rotate Up
        if(num > 4.0f)
        {
            mouse = (Vector3.up * 90);
        }
        // Rotate down
        if(num <= 4.0f && num > 3.0f)
        {
            mouse = (Vector3.down * 90);
        }
        // Rotate right
        if(num <= 3.0f && num > 2.0f)
        {
            mouse = (Vector3.right * 90);
        }
        // Rotate left
        if(num <= 2.0f && num >= 1.0f)
        {
            mouse = (Vector3.left * 90);
            
        }

        activeSide = cubeState.front;
        pivotU.randomRotate(activeSide, mouse);

    }

}
