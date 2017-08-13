using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public bool IsPlayableCharacter = false;

    public GameObject Hand;
    public Item HeldItem;
    public GameObject Storage;
    public List<Item> Items = new List<Item>();

    void Update()
    {
        if (!IsPlayableCharacter) return;

        var activeSlot = -1;

        if (Input.GetButtonDown("Slot1"))
            activeSlot = 0;
        if (Input.GetButtonDown("Slot2"))
            activeSlot = 1;
        if (Input.GetButtonDown("Slot3"))
            activeSlot = 2;
        if (Input.GetButtonDown("Slot4"))
            activeSlot = 3;

        if (activeSlot >= 0)
        {
            if(Items.Count > activeSlot)
                HoldItem(Items[activeSlot]);
            else
                StoreItem(HeldItem);
        }
    }

    public bool AddItem(Item item)
    {
        if (Items.Count >= 4) return false;
        Items.Add(item);
        StoreItem(item);
        return true;
    }

    public Item RemoveItem(Item item)
    {
        if (Items.Remove(item))
            return item;
        return null;
    }

    private void HoldItem(Item item)
    {
        StoreItem(HeldItem);

        if(item != null)
        {
            item.transform.position = Hand.transform.position;
            item.transform.localEulerAngles = Vector3.zero;
            item.transform.parent = Hand.transform;
            item.gameObject.SetActive(true);
        }
    }

    private bool StoreItem(Item item)
    {
        if (item == null) return false;
        item.transform.parent = Storage.transform;
        item.transform.position = transform.position;
        item.gameObject.SetActive(false);
        return true;
    }
}
