using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public GameObject cube;
    public void Reset()
    {
        DestroyImmediate(cube,true);

        Instantiate(cube);
    }
   
}
