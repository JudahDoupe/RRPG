using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name = "";
    public string Description = "";

    public Item Transfer(GameObject newParent)
    {
        transform.parent = newParent.transform;
        gameObject.SetActive(false);
        transform.position = newParent.transform.position;
        return this;
    }
}
