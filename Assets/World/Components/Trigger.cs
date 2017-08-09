using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public ETriggerActions Action;
    public ETriggerReactions Reaction;

    public string Message;
    public GameObject Target;
    public float Proximity;

    public Inventory Inventory;
    public QuestLog QuestLog;


    public void Update()
    {
        if (ShouldTrigger())
            ActivateTrigger();
       
    }

    public bool ShouldTrigger()
    {
        switch (Action)
        {
            case ETriggerActions.Proximity:
                return Vector3.Distance(Target.transform.position, transform.position) <= Proximity;
            case ETriggerActions.LeftClick:
                return FW_Cursor.Instance.HoverObject != null && FW_Cursor.Instance.HoverObject.Equals(transform) && Input.GetMouseButtonDown(0);
            case ETriggerActions.RightClick:
                return FW_Cursor.Instance.HoverObject != null && FW_Cursor.Instance.HoverObject.Equals(transform) && Input.GetMouseButtonDown(1);
            case ETriggerActions.E:
                return Vector3.Distance(Target.transform.position, transform.position) <= Proximity && Input.GetButtonDown("Interact");
        }
        return false;
    }

    public void ActivateTrigger()
    {
        switch (Reaction)
        {
            case ETriggerReactions.Message:
                Debug.Log(Message);
                break;
            case ETriggerReactions.BeginDiolog:
                //TODO impliment Diolog
                break;
            case ETriggerReactions.TransferItem:
                var inventory = Target.GetComponent<Inventory>();
                if (inventory != null)
                {
                    for(int i = 0; i < Inventory.Items.Count; i++)
                    {
                        inventory.AddItem(Inventory.RemoveItem(Inventory.Items[0]));
                    }
                }
                break;
            case ETriggerReactions.TransferQuest:
                var questLog = Target.GetComponent<QuestLog>();
                if (questLog != null)
                {
                    for (int i = 0; i < QuestLog.Quests.Count; i++)
                    {
                        questLog.AddQuest(QuestLog.RemoveQuest(QuestLog.Quests[0]));
                    }
                }
                break;
        }
    }
}
