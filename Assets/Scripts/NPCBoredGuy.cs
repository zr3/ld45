using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBoredGuy : NPCBase
{
    void AwareOfPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("Hey.");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        if (!GameOrchestrator.Instance.BoredGuyHealed)
        {
            MessageController.AddMessage("... *sigh*...");
            MessageController.AddMessage("So.");
            MessageController.AddMessage("Bored.");
        }
        else
        {
            MessageController.AddMessage("Hey, ha! Hey, ha!");
            MessageController.AddMessage("Island life is good, mate!");
        }
    }

    void SongPlayed(Player.Song song)
    {
        MessageController.SetLookTarget(transform);
        if (song == Player.Song.HappyJig)
        {
            MessageController.AddMessage("Ahhhhhh....");
            MessageController.AddMessage("That tune....");
            MessageController.AddMessage("YEAAHHHHHH BOIIIIIII!");
            MessageController.AddMessage("That'll be stuck in my head until the festival! I love it!");

            MessageController.AddMessage("Let me tell you a story. I'm in such a good mood!");
            MessageController.AddMessage("The world is going to end!");
            MessageController.AddMessage(":D");
            MessageController.AddMessage("They say there's a creature that can help us, though.");
            MessageController.AddMessage("Or maybe it's a being. Or an entity.");
            MessageController.AddMessage("Or maybe, nothing at all.");
            MessageController.AddMessage("Anyway, there's a relic in the north, and a relic in the south.");
            MessageController.AddMessage("They say if someone finds them, they'll learn how to summon her.");
            GameOrchestrator.Instance.BoredGuyHealed = true;
        }
        else if (song == Player.Song.SadShanty)
        {
            MessageController.AddMessage("Ah....");
            MessageController.AddMessage("That tune....");
            MessageController.AddMessage("It's so sad. Beautiful, but depressing!");
        }
    }
}
