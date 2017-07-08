using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct QuestData{

    public GameObject Target { get; set; }

    public GameObject Proximity { get; set; }

    public Item Reward { get; set; }

    public int NarativeImportance { get; set; }

    public string Title { get; set; }

    public bool IsComplete { get; set; }

    public List<QuestResolutions> Resolutions { get; set; }
}
