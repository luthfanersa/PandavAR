using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 0.001f);
    }
}
