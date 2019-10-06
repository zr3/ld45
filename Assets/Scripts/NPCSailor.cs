using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSailor : MonoBehaviour
{
    void AwareOfPlayer()
    {
        MessageController.AddMessage("Ahoy!");
    }

    void TalkToPlayer()
    {
        if (!GameOrchestrator.Instance.HasLoveLetter && !GameOrchestrator.Instance.DeliveredLoveLetter)
        {
            MessageController.AddMessage("Great day for a sail, innit?");
            MessageController.AddMessage("Lookin' forward to the fire festival?");
        } else if (GameOrchestrator.Instance.HasLoveLetter)
        {
            GameOrchestrator.Instance.HasLoveLetter = false;
            GameOrchestrator.Instance.DeliveredLoveLetter = true;
            MessageController.AddMessage("Oh, this is from that lass over on the shoreline?");
            MessageController.AddMessage("...");
            MessageController.AddMessage("Y'know, I have eyes for her too! Mate, this is great news!");
            MessageController.AddMessage("It makes me so happy, I wanna do a jig!");

            MessageController.AddMessage("You learned the HAPPY JIG! Share the excitement!");
            GameOrchestrator.Instance.HasHappyJig = true;
        } else
        {
            MessageController.AddMessage("Yo ho, YOLO a pirate's life for me.");
        }
    }
}
