using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

    public Text text;

    void Update () {

        var obj = FW_Cursor.Instance.HoverObject;

        if (obj != null)
        {
            var screenPos = Camera.main.WorldToScreenPoint(obj.root.position);
            text.rectTransform.position = screenPos;
            text.text = obj.root.name;
        }
        else
        {
            text.text = "";
        }
    }
}
