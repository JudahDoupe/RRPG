using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFactory : MonoBehaviour {

    public Resolution OnRecieve;

    public static QuestFactory Instance;

    void Awake()
    {
        Instance = Instance ?? this;
    }

    public Quest Build(QuestData quest, GameObject questLog)
    {
        var rtn = questLog.AddComponent<Quest>();

        rtn.Target = quest.Target;
        rtn.Reward = quest.Reward;
        rtn.NarativeImportance = quest.NarativeImportance;
        rtn.Title = quest.Title;
        rtn.IsComplete = quest.IsComplete;
        rtn.Resolutions = quest.Resolutions;

        return rtn;
    }
}
