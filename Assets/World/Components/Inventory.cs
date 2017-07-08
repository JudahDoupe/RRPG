using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public GameObject Object;
    public List<Item> Items = new List<Item>();

    public void AddItem(ItemData item)
    {
        var newItem = ItemFactory.Instance.Build(item, Object);
        newItem.Inventory = this;
        Items.Add(newItem);
    }

    public ItemData RemoveItem(Item item)
    {
        var data = item.ToData();
        Items.Remove(item);
        Destroy(item);
        return data;
    }
}
