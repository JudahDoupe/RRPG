using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public Inventory Inventory;

    public string Name;

    public string Description;

    public GameObject Object;


    public ItemData ToData()
    {
        return new ItemData
        {
            Name = Name,
            Description = Description,
            Object = Object,
        };
    }
}
