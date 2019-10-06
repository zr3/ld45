using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShipwrecked : NPCBase
{
    private float initialMaxSpeed;

    private void Start()
    {
        initialMaxSpeed = Player.Instance.MaxSpeed;
    }
    void AwareOfPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("OYYYYYYY!");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        // if they have the boat
        if (Player.Instance.MaxSpeed > initialMaxSpeed)
        {
            MessageController.AddMessage("Oi mate!");
            MessageController.AddMessage("I wrecked me ship up on these rocks!");
            MessageController.AddMessage("... obviously ...");
            MessageController.AddMessage("I won't be needin' this sail.");
            MessageController.AddMessage("You got a SAIL for your boat! Hold [shift] to use it. Now you can go even faster!");
            MessageController.AddMessage("Welp..");
            MessageController.AddMessage("I've no reason to live anymore. Cheers!");
            Player.Instance.SailAvailable = true;
            GameOrchestrator.Instance.HasSail = true;
            Destroy(gameObject);
        } else
        {
            MessageController.AddMessage("Oi what're you doing out here without a ship?!");
            MessageController.AddMessage("... crazy landlubbers ...");
        }
    }
}
