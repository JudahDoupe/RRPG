using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject InventoryStorage;
    public List<Item> Storage = new List<Item>();

    public bool TransferItem(Item item)
    {
        if (Storage.Contains(item) || item == null) return false;
        Debug.Log("You Recieved Item: " + item.Name);

        var newObj = item.Transfer(InventoryStorage);
        Storage.Add(newObj);

        return true;
    }
}
