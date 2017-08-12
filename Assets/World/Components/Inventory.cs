using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject Object;
    public List<Item> Items = new List<Item>();

    void Start()
    {
    }

    public void AddItem(Item item)
    {
        item.Inventory = this;
        Items.Add(item);
        item.transform.parent = transform;
        item.transform.position = transform.position;
        item.gameObject.SetActive(false);
    }

    public Item RemoveItem(Item item)
    {
        Items.Remove(item);
        return item;
    }
}
