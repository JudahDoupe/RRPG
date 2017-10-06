using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources {

    private Culture _culture;

    public int land = 25;
    public int food = 2;
    public int houses = 1;

    public Resources(Culture culture)
    {
        _culture = culture;
    }
}
