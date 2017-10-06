using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtentions{

    public static int Floor(this float val)
    {
        return Mathf.FloorToInt(val);
    }
}
