using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    [HideInInspector]
    public Inventory Inventory;
    public GameObject Storage;
    public List<Quest> Quests = new List<Quest>();

    void Start()
    {
        Inventory = transform.GetComponent<Inventory>();
    }

    public void AddQuest(Quest quest)
    {
        quest.Log = this;
        Quests.Add(quest);
        quest.transform.parent = transform;
        quest.transform.position = transform.position;
    }

    public Quest RemoveQuest(Quest quest)
    {
        Quests.Remove(quest);
        return quest;
    }
}
