using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShipwrecked : MonoBehaviour
{
    private float initialMaxSpeed;

    private void Start()
    {
        initialMaxSpeed = Player.Instance.MaxSpeed;
    }
    void AwareOfPlayer()
    {
        MessageController.AddMessage("OYYYYYYY!");
    }

    void TalkToPlayer()
    {
        // if they have the boat
        if (Player.Instance.MaxSpeed > initialMaxSpeed)
        {
            MessageController.AddMessage("Oi mate!");
            MessageController.AddMessage("I wrecked me ship up on these rocks!");
            MessageController.AddMessage("... obviously ...");
            MessageController.AddMessage("I won't be needin' this sail.");
            MessageController.AddMessage("You got a SAIL for your boat! Now you can go even faster!");
            MessageController.AddMessage("Welp..");
            MessageController.AddMessage("I've no reason to live anymore. Cheers!");
            Player.Instance.SailAvailable = true;
            Destroy(gameObject);
        } else
        {
            MessageController.AddMessage("Oi what're you doing out here without a ship?!");
            MessageController.AddMessage("... crazy landlubbers ...");
        }
    }
}
