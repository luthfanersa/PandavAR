using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DescTrigger : MonoBehaviour
{
    public UnityEvent unityEvent;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
