using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfContainer : MonoBehaviour
{
    GameObject[] priceTags;

    public GameObject Player;

    int x = 0;
    void Start()
    {
        if(priceTags == null)
        {
            priceTags = GameObject.FindGameObjectsWithTag("PriceTag");
        }

        foreach (var item in priceTags)
        {
            item.gameObject.SetActive(false);
            Debug.Log(++x);
        }
    }

    void Update()
    {
        CheckDistance(priceTags);
    }

    void CheckDistance(GameObject[] PriceTags)
    {
        foreach (var item in PriceTags)
        {
            if(Vector3.Distance(Player.transform.position, item.transform.position) < 25.0f)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
