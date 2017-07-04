using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonalNarritive : MonoBehaviour {

    public int activeObjectives = 0;
    public int completedObjectives = 0;

    public GameObject objectiveStorage;

    void Update()
    {
        activeObjectives = Objectives.Count;

        foreach (Objective obj in Objectives)
        {
            if (obj.IsComplete()){
                ResolveObjective(obj);
                break;
            }
        }
    }

    private List<Objective> Objectives = new List<Objective>();

    public bool TransferObjective(Objective obj)
    {
        if (Objectives.Contains(obj) || obj == null) return false;
        Debug.Log("You Recieved Objective: " + obj.Title);

        var newObj = obj.Transfer(objectiveStorage);
        Objectives.Add(newObj);

        return true;
    }
    public bool ResolveObjective(Objective obj)
    {
        if (!Objectives.Contains(obj)) return false;

        obj.Resolve();
        completedObjectives++;
        Objectives.Remove(obj);
        Debug.Log("You Completed Objective: " + obj.Title);
        return true;
    }

    public Objective GetMainObjective()
    {
        Objective main = null;
        foreach (Objective obj in Objectives)
        {
            if(main == null || obj.NarativeImportance >= main.NarativeImportance)
                main = obj;
        }
        return main;
    }

}
