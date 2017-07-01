using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_Input{

    public static FW_Input Instance = null;
	void Awake () { if (Instance == null) Instance = new FW_Input();}

    public char MovementKey {
        get
        {
            bool w = Input.GetKeyDown("w");
            bool s = Input.GetKeyDown("s");

            if (s && !w) return 's';
            else if (w && !s) return 'w';
            else return '\0';
        }
    }
    public char StrafeKey {
        get
        {
            bool w = Input.GetKeyDown("a");
            bool s = Input.GetKeyDown("d");

            if (s && !w) return 'a';
            else if (w && !s) return 'd';
            else return '\0';
        }
    }


    void Update () {
		
	}

}
