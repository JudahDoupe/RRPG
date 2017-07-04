using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP_Item : InterestPoint {

    public Item item;

    public override void Activate(GameObject activator)
    {
        item = item ?? gameObject.GetComponent<Item>();
        FW_Players.Player.GetComponent<Inventory>().TransferItem(item);
        Destroy(this);
    }
}
