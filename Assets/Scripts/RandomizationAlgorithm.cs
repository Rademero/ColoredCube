using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizationAlgorithm : MonoBehaviour
{
    public Transform cube;
    // The number of moves it does for randomization of the cube.
    private int maxMoves = 64;
    // Counter used for the rotations.
    private int numMoves = 0;

    Vector3 mouse;

    public PivotRotation pivot;

    List<GameObject> activeSide;


    void Update()
    {
        
        float random;
        if (numMoves < maxMoves)
        {
            random = Random.Range(-1.0f, 5.0f);
            print(random);
            //chooseCommand(random);
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
            mouse = Vector3.up;
        }
        // Rotate down
        if(num <= 4.0f && num > 3.0f)
        {
            mouse = Vector3.down;
        }
        // Rotate right
        if(num <= 3.0f && num > 2.0f)
        {
            mouse = Vector3.right;
        }
        // Rotate left
        if(num <= 2.0f && num >= 1.0f)
        {
            mouse = Vector3.left;
        }

        pivot.setMouseRef(mouse);

        pivot.Update();

    }

}
