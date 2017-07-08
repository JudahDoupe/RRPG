using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {

    public static ItemFactory Instance;

    void Awake()
    {
        Instance = Instance ?? this;
    }

    public Item Build(ItemData item, GameObject Inventory)
    {
        var rtn = Inventory.AddComponent<Item>();

        rtn.Name = item.Name;
        rtn.Description = item.Description;
        rtn.Object = item.Object;
        rtn.Object.transform.parent = Inventory.transform.parent;
        rtn.Object.transform.position = Inventory.transform.position;

        return rtn;
    }
}
