using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject UIArrows;

    public GameObject spawnedObject;
    //private bool placementPoseIsValid = false;
    //public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    Vector2 first_touch;
    Vector2 second_touch;
    float distance_current;
    float distance_previous;
    bool first_pinch = true;

    public GameObject[] arModels;
    int modelIndex = 0;

    void Start()
    {
     
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        UIArrows.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
           if (spawnedObject == null)
            {
                ARPlaceObject(modelIndex);
                UIArrows.SetActive(true);
               
                //single object script:
                //spawnedObject = Instantiate(objectToSpawn,
                //placementIndicator.transform.position, placementIndicator.transform.rotation);
            }
       

            //to move the spawned object to a position
            //  else
            //  {
            //   spawnedObject.transform.position = placementIndicator.transform.position;
            //  }
        }

        if (Input.touchCount > 1 && spawnedObject)
        {
            first_touch = Input.GetTouch(0).position;
            second_touch = Input.GetTouch(1).position;
            distance_current = second_touch.magnitude - first_touch.magnitude;
            if (first_pinch)
            {
                distance_previous = distance_current;
                first_pinch = false;
            }
            if (distance_current != distance_previous)
            {
                Vector3 scale_value = spawnedObject.transform.localScale * (distance_current / distance_previous);
                spawnedObject.transform.localScale = scale_value;
                distance_previous = distance_current;
            }
        }
        else
        {
            first_pinch = true;
        }
    }


   

    void ARPlaceObject(int id)
    {
        for (int i = 0; i < arModels.Length; i++)
        {
            if (i == id)
            {
                GameObject clearUp = GameObject.FindGameObjectWithTag("ARMultiModel");
                Destroy(clearUp);
                spawnedObject = Instantiate(arModels[i], placementIndicator.transform.position, placementIndicator.transform.rotation);
            }
        }


    }

    public void ModelChangeRight()
    {
        if (modelIndex < arModels.Length - 1)
            modelIndex++;
        else
            modelIndex = 0;

        ARPlaceObject(modelIndex);
    }
    public void ModelChangeLeft()
    {
        if (modelIndex > 0)
            modelIndex--;
        else
            modelIndex = arModels.Length - 1;

        ARPlaceObject(modelIndex);
    }

    public void ModelDesc()
    {
        //modelIndex. deskripsi
    }
}
