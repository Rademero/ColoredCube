using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizationAlgorithm : MonoBehaviour
{
    public Transform cube;
    private int maxMoves = 64;
    private int numMoves = 0;

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

        /*   if(Input.GetKey("z"))
         * {
         *    random = Random.Range(-1.0f, 5.0f);
         *       print(random);
         *      chooseCommand(random);
         * }
         */

    }

}
