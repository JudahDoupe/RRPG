using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint: MonoBehaviour
{
    public ActiveState State = ActiveState.Idle;

    public static float proximity = 2.5f;

    public bool ProximitySensitive = false;
    public bool ClickSensitive = true;

    void Update()
    {
        if (ProximitySensitive && Vector3.Distance(FW_Players.Player.transform.position, transform.position) < proximity)
        {
            OnProximity();
        }
    }

    public void OnLeftClick()
    {
        if (State == ActiveState.Idle && ClickSensitive) Activate(FW_Players.Player);
    }
    public void OnProximity()
    {
        if (State == ActiveState.Idle && ProximitySensitive) Activate(FW_Players.Player);
    }

    public virtual void Activate(GameObject player)
    {
    }
}
