using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(cam.transform.position, cam.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 500))
        {
            Debug.Log(hit.transform.position.ToString());
        }

 
        
    }
}
