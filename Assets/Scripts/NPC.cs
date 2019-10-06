using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : NPCBase
{
    private void Start()
    {
        GameOrchestrator.Instance.RegisterForSongs(song =>
        {
            if (song == Player.Song.Windwards)
            {
                TalkToPlayer();
            }
        });
    }
    void AwareOfPlayer() {
        // ui effect and animation
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("Hey!");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        if (!GameOrchestrator.Instance.HasBoat)
        {
            MessageController.AddMessage("Listen! You must be new here.");
            MessageController.AddMessage("You don't want to be soggy like me. There's a boat over on that island you can use, go grab it!");
            MessageController.AddMessage("There are a lot of folks around here. We're getting ready for the fire festival later tonight!");
            MessageController.AddMessage("It's going to be a blast. We pray to the gods so they don't kill us all!");
            if (!GameOrchestrator.Instance.HasWindwards)
            {
                MessageController.AddMessage("It can get kind of wild out here, so let me teach you this song. It will carry across the winds, and we'll be able to magically talk any time!");
                MessageController.AddMessage("You learned the song WINDWARDS!");
                GameOrchestrator.Instance.HasWindwards = true;
            }

        } else
        {
            MessageController.AddMessage("Ready for the fire festival?");
        }
    }
}
