﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatItem : MonoBehaviour
{
    public float NewMaxSpeed = 8;

    void AwareOfPlayer()
    {

    }

    void ItemActivate()
    {
        Player.Instance.MaxSpeed = NewMaxSpeed;
        MessageController.AddMessage("You found a BOAT! Now you don't have to worry about drowning!");
        GameOrchestrator.Instance.HasBoat = true;
        Destroy(gameObject);
    }
}
