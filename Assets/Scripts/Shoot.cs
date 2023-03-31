using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject boom;

    //untuk shooter game
    public void Attack()
    {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if(hit.transform.tag=="Enemy")
            {
                Destroy(hit.transform.gameObject);

                Instantiate(boom, hit.point, Quaternion.LookRotation(hit.normal));

                ScoreManager.instance.AddPoint();
            }
        }
    }

   

    
}
