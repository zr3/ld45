using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWife : MonoBehaviour
{
    void AwareOfPlayer()
    {
        if (!GameOrchestrator.Instance.SavedSailor)
            MessageController.AddMessage("yoo hoo!");
        else if (!GameOrchestrator.Instance.DeliveredSailor)
            MessageController.AddMessage("WHAT'S THIS?!");
        else
            MessageController.AddMessage("hmph.");
    }

    void TalkToPlayer()
    {
        if (!GameOrchestrator.Instance.SavedSailor)
        {
            MessageController.AddMessage("Well hello there, darling.");
            MessageController.AddMessage("You look mighty fine out there.");
            MessageController.AddMessage("My husband has been out on the sea all day...");
            MessageController.AddMessage("*wink");
        }
        else if (!GameOrchestrator.Instance.DeliveredSailor)
        {
            MessageController.AddMessage("HUGH! Where is our ship?!?!");
            MessageController.AddMessage("SHARKS!?!?!");
            MessageController.AddMessage("hmph.. well at least you're all right.");
            MessageController.AddMessage("Young sailor, thank you for bringing my husband home.");
            MessageController.AddMessage("That ship had been in our family for generations...");
            MessageController.AddMessage("Let me sing you a song that my grandmother taught me. It is an old ballad that we would sing when ships didn't come home.");
            MessageController.AddMessage("You learned the SAD SHANTY! It's a song about loss on the high seas.");
            GameOrchestrator.Instance.HasSadShanty = true;
            GameOrchestrator.Instance.DeliveredSailor = true;
        } else
        {
            MessageController.AddMessage("There once was a ship, that could not be sunken -- at least so long the crew wern't drunken...");
        }
    }
}
