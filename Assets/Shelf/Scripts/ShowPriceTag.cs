using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPriceTag : MonoBehaviour
{
    public GameObject priceTagCanvas;
    void Start()
    {
        priceTagCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ToggleVisibility(bool visibility)
    {
        priceTagCanvas.SetActive(visibility);
    }


}
