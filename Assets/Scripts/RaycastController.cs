using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public float range = 50f;

    public Camera fpsCam;

    public ShowPriceTag shelf;

    private bool isRaycastHitting;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {       

            if(hit.collider.tag == "Shelf")
            {
               hit.transform.SendMessage("ToggleVisibility", true);

                shelf = hit.transform.gameObject.GetComponent<ShowPriceTag>();

                isRaycastHitting = true;
            }
        }
        else if (isRaycastHitting)
        {
            shelf.ToggleVisibility(false);

            shelf = null;

            isRaycastHitting = false;
        }
    }
}
