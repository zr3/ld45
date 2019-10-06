using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSadGuy : NPCBase
{
    void AwareOfPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("...");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        if (!GameOrchestrator.Instance.SadGuyHealed)
        {
            MessageController.AddMessage("... *sigh*...");
            MessageController.AddMessage("The life of a sailor is a dangerous one, that's fer sure.");
            MessageController.AddMessage("Sometimes it feels like there is no way to heal the heart...");
        } else
        {
            MessageController.AddMessage("The sailor's life is a hard one, and sometimes a short one.");
            MessageController.AddMessage("But life does go on. Thank ye, mate.");
        }
    }

    void SongPlayed(Player.Song song)
    {
        MessageController.SetLookTarget(transform);
        if (song == Player.Song.SadShanty)
        {
            MessageController.AddMessage("Ahhhhhh....");
            MessageController.AddMessage("That tune....");
            MessageController.AddMessage("...");
            MessageController.AddMessage("It's so sad, but the singer sails on...");
            MessageController.AddMessage("Just like I must...");
            MessageController.AddMessage("Thank ye, friend. My crew may be gone, but I must go on.");
            MessageController.AddMessage("Let me tell ye about the legend of this land and sea...");

            MessageController.AddMessage("Year by year, we worship the fire mountain.");
            MessageController.AddMessage("Praying she not end us all.");
            MessageController.AddMessage("She acts up, but always calms down.");
            MessageController.AddMessage("This year though...");
            MessageController.AddMessage("She be looking redder than usual.");
            MessageController.AddMessage("And legend has it, every 1000 years...");
            MessageController.AddMessage("Well, the horror is...");
            MessageController.AddMessage("...");
            MessageController.AddMessage("... hopefully not this year.");
            GameOrchestrator.Instance.SadGuyHealed = true;
        } else if (song == Player.Song.HappyJig)
        {
            MessageController.AddMessage("Ahhhhhh....");
            MessageController.AddMessage("That tune....");
            MessageController.AddMessage("Reminds me of the good times with me old crew...");
        }
    }
}
