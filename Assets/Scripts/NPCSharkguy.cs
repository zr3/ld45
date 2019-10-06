using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSharkguy : MonoBehaviour
{
    void AwareOfPlayer()
    {
        MessageController.AddMessage("aaaaAAAAHHHaaaaAAAHH!");
    }

    void TalkToPlayer()
    {
        MessageController.AddMessage("*glurb* help!");
        if (GameOrchestrator.Instance.HasBoat)
        {
            if (GameOrchestrator.Instance.SharksKilled < 1)
            {
                MessageController.AddMessage("Mate, I have a *glrpble* wife!");
                MessageController.AddMessage("You have to help meee*blbbblblblbb*!");
                MessageController.AddMessage("That boat *glrp* looks like a good rammer -- ram the sharks!");
            } else if (GameOrchestrator.Instance.SharksKilled < 4)
            {
                MessageController.AddMessage("There are still some left!");
                MessageController.AddMessage("*glrhprh*");
            } else
            {
                MessageController.AddMessage("Phew. You showed them sharks.");
                MessageController.AddMessage("Hope you don't mind if I hop on board!");
                MessageController.AddMessage("Me wife lives on the heart-shaped island. She'll be so happy to see me, she'll give ye something good!");
                GameOrchestrator.Instance.SavedSailor = true;
                Destroy(gameObject);
            }
        }
        else
        {
            MessageController.AddMessage("*blurbl* actually ...");
            MessageController.AddMessage("You're in the *blbblb* same boat as me!");
            MessageController.AddMessage("Same *blibble* lack of boat, that is...");
        }
    }
}
