using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGen : MonoBehaviour {

	void Start () {
        //Debug.Log(new QuestGrammar().Text);
	}
	
}

public class QuestGrammar
{
    public string Text = "";
    public bool hasItem = false;
    public bool hasArea = false;
    public bool isFetch = false;

    public QuestGrammar()
    {
        Text = Quest() + Reason();
    }

    private string Quest()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                return "Go to " + Area() + "and " + QuestAction() + ".  ";
            default:
                return QuestAction();
        }
    }

    private string QuestAction()
    {
        string val = "";

        switch (Random.Range(0, 3))
        {
            case 0:
                val += QuestAction() + "and then " + QuestAction();
                break;
            case 1:
            default:
                if (hasArea)
                {
                    val += AreaAction() + "the area ";
                    break;
                }
                val += ItemAction() + Item();
                break;
        }


        if (isFetch && !hasArea)
        {
            val += "at " + Area();
        }

        return val;
    }

    private string Area()
    {
        hasArea = true;
        switch (Random.Range(0, 7))
        {
            case 0:
                return "the mountains ";
            case 1:
                return "the swamp ";
            case 2:
                return "the forest ";
            case 3:
                return "the other village ";
            case 4:
                return "the beach ";
            case 5:
                return "the jungle ";
            default:
                return "your home ";
        }
    }

    private string Item()
    {
        hasItem = true;
        switch (Random.Range(0, 7))
        {
            case 0:
                return "a tool ";
            case 1:
                return "a part ";
            case 2:
                return "a weapon ";
            case 3:
                return "an artifact ";
            case 4:
                return "a writting ";
            case 5:
                return "a relic ";
            default:
                return "a statue ";
        }
    }

    private string ItemAction()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                return "steal ";
            case 1:
                return "destroy ";
            case 2:
                return "retrieve ";
            default:
                return "find ";
        }
    }

    private string AreaAction()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                return "explore ";
            case 1:
                return "scout ";
            case 2:
                return "travel to ";
            default:
                return "draw a map of ";
        }
    }



    private string Reason()
    {
        return "";
    }
}