using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferItem : Action
{
    public Inventory ItemOwner;
    public Inventory ItemReceiver;
    public Item Item;

    public override void Execute()
    {
        ItemReceiver.AddItem(ItemOwner.RemoveItem(Item));
    }
}
