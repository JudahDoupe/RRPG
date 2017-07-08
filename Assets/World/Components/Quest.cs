using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public bool Inactive = false;

    public QuestLog Log;

    public string Title;

    public Item Reward;

    public bool IsComplete;

    public int NarativeImportance;

    public GameObject Target;

    public float Proximity;



    public List<QuestResolutions> Resolutions;



    public void Update()
    {
        if ( !Inactive && ShouldResolve())
            Resolve();
    }

    public void Resolve()
    {
        if(Reward != null)Log.Inventory.AddItem(Reward.ToData());
        IsComplete = true;
        Resolutions = new List<QuestResolutions>();
        Debug.Log("Completed Quest: " + Title);
    }

    public QuestData ToData()
    {
        return new QuestData
        {
            Target = Target,
            Reward = Reward,
            NarativeImportance = NarativeImportance,
            Title = Title,
            IsComplete = IsComplete,
            Resolutions = Resolutions,
        };
    }

    private bool ShouldResolve()
    {
        if (IsComplete) return false;

        var rtn = true;
        Resolutions.ForEach(r => rtn = IsResolved(r) ? rtn : false);

        return rtn;
    }

    public bool IsResolved(QuestResolutions type)
    {
        if (type == QuestResolutions.OnReceive)
            return true;
        if (type == QuestResolutions.OnProximity)
            return Vector3.Distance(transform.position, Target.transform.position) < Proximity;
        if (type == QuestResolutions.OnTargetNull)
            return Target == null;
        return false;
    }
}
