using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;
    //sets up the cube maps for visual
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();
        //outputs the color to the cube map visual
       UpdateMap(cubeState.front, front);
       UpdateMap(cubeState.back, back);
       UpdateMap(cubeState.left, left);
       UpdateMap(cubeState.right, right);
       UpdateMap(cubeState.up, up);
       UpdateMap(cubeState.down, down);
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;//index for the side
        //Checks what color the ray is looking at
        foreach(Transform map in side)
        {
            if (face[i].name[4] == 'O')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[4] == 'R')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name[4] == 'B')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name[4] == 'G')
            {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name[4] == 'W')
            {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[4] == 'Y')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            i++;
        }
    }
}
