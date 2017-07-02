using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_MouceOver{
    private static FW_MouceOver instance;
    public static FW_MouceOver Instance{ get { return instance ?? new FW_MouceOver(); } }

    private float LineOfSight = 100;

    public Transform Object{
        get
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, LineOfSight))
            {
                return hit.transform;
            }
            else
            {
                return null;
            }
        }
    }
    public Vector3? Point {
        get
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                return hit.point;
            }else
            {
                return null;
            }
        }
    }
}
