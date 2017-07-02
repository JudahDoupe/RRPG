using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMessanger : MonoBehaviour {

    void Update()
    {
        CheckClicks();
    }

    private void CheckClicks()
    {
        if (Input.GetMouseButtonDown(0))
            SendClick("OnLeftClick");

        if (Input.GetMouseButtonDown(1))
            SendClick("OnRightClick");

        if (Input.GetMouseButtonDown(2))
            SendClick("OnMiddleClick");
    }
    private void  SendClick(string clickString)
    {
        var clickedObject = FW_MouceOver.Instance.Object;
        if(clickedObject != null)
            clickedObject.SendMessage(clickString, FW_MouceOver.Instance.Point, SendMessageOptions.DontRequireReceiver);
    }
}
