using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLover : NPCBase
{
    void AwareOfPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("Hey!");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        if (!GameOrchestrator.Instance.HasLoveLetter && !GameOrchestrator.Instance.DeliveredLoveLetter)
        {
            MessageController.AddMessage("You look like you might be able to help me!");
            MessageController.AddMessage("There's... someone out on the water who sails by here in his ship...");
            MessageController.AddMessage("Could you give him this for me?");
            MessageController.AddMessage("You got the LOVE LETTER!");
            GameOrchestrator.Instance.HasLoveLetter = true;
        }
        else if (GameOrchestrator.Instance.HasLoveLetter)
        {
            MessageController.AddMessage("Did you find him yet?");
        }
        else
        {
            MessageController.AddMessage("It's such a nice day for a swim!");
        }
    }
}
