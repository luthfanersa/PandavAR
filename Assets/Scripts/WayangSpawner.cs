using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject UIArrows;

    // public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public GameObject[] arModels;
    int modelIndex = 0;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        UIArrows.SetActive(false);

    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(modelIndex);
            UIArrows.SetActive(true);
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid && spawnedObject == null)
        {
            PlacementPose = hits[0].pose;
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
                spawnedObject = Instantiate(arModels[i], PlacementPose.position, PlacementPose.rotation);
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

}
