using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.back * Time.deltaTime * 1f);
    }
}
