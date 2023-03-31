using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    private void Start()
    {
        // get components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide placement visual
        //visual.SetActive(false);
    }

    private void Update()
    {
        // shoot raycast from center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit an AR plane, update the position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
                visual.SetActive(true);
        }
        

    }

    public void Disable()
    {
        
            visual.SetActive(false);
        
    }
}
