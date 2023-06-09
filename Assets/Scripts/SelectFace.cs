﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    CubeState cubeState;
    ReadCube readCube;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            readCube.ReadState();

            //raycast from mouse to select face
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                GameObject face = hit.collider.gameObject;
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                 {
                     cubeState.up,
                     cubeState.down,
                     cubeState.left,
                     cubeState.right,
                     cubeState.front,
                     cubeState.back
                };

                foreach(List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        cubeState.PickUp(cubeSide);
                    }
                }
            }

        }
    }
}
