using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizationAlgorithm : MonoBehaviour
{
    // The number of moves it does for randomization of the cube.
    private int maxMoves = 15;
    // Counter used for the rotations.
    private int numMoves = 0;

    Vector3 mouse;

    private PivotRotation pivot;
    List<GameObject> activeSide;
    private CubeState cubeState;

    void Start()
    {
        pivot = FindObjectOfType<PivotRotation>();
        cubeState = FindObjectOfType<CubeState>();
    }


    void Update()
    {
        
        float random;
        if (numMoves < maxMoves)
        {
            random = Random.Range(1.0f, 5.0f);
            print(random);
            chooseCommand(random);
            numMoves = numMoves + 1;
        }

        // Used for testing purposes 
        if (Input.GetKey("z"))
        {
            random = Random.Range(1.0f, 5.0f);
            print(random);
            //chooseCommand(random);
        }


    }

    // Chooses how to rotate the cube.
    void chooseCommand(float num)
    {
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
        pivot.randomRotate(activeSide, mouse);

    }

}
