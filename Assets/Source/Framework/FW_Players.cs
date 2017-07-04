using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_Players : MonoBehaviour {
    public GameObject player;
    public static GameObject Player;

    void Awake()
    {
        Player = player;
    }
}
