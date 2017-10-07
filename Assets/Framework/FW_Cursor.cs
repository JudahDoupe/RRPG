using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_Cursor{
    private static FW_Cursor instance;
    public static FW_Cursor Instance{ get { return instance ?? new FW_Cursor(); } }

    public float LineOfSight = 25;
    public float Sesitivity = 1;

    public bool IsLocked
    {
        get { return !Cursor.visible; }
        set
        {
            if (value)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public Vector3 Position
    {
        get
        {
            if (IsLocked) return new Vector3(Screen.width/2f, Screen.height/2f, 0f);
            else return Input.mousePosition;
        }
    }

    public Transform HoverObject{
        get
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Position);
            if (Physics.Raycast(ray, out hit, LineOfSight))
                return hit.transform;
            else
                return null;
        }
    }

    public Vector3? HoverPoint {
        get
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Position);
            if (Physics.Raycast(ray, out hit))
                return hit.point;
            else
                return null;
        }
    }
}
