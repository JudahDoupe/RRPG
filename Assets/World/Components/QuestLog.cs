using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public Inventory Inventory;
    public GameObject Object;
    public List<Quest> Quests = new List<Quest>();

    public void AddQuest(QuestData quest)
    {
        var newQuest = QuestFactory.Instance.Build(quest, Object);
        newQuest.Log = this;
        Quests.Add(newQuest);
    }

    public QuestData RemoveQuest(Quest quest)
    {
        var data = quest.ToData();
        Quests.Remove(quest);
        Destroy(quest);
        return data;
    }

    public Quest GetMainQuest()
    {
        Quest main = null;
        Quests.ForEach(q => main = q.NarativeImportance >= main.NarativeImportance ? q : main);
        return main;
    }
}
