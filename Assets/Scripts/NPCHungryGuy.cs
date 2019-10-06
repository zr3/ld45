using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHungryGuy : MonoBehaviour
{
    void AwareOfPlayer()
    {
        // ui effect and animation
    }

    void TalkToPlayer()
    {
        if (GameOrchestrator.Instance.Bananas < 1)
        {
            MessageController.AddMessage("*uurgff*");
            MessageController.AddMessage("I'm so hungry...");
            MessageController.AddMessage("... and lazy ...");
            MessageController.AddMessage("Find me some bananas, please...");
        } else if (GameOrchestrator.Instance.Bananas < 6)
        {
            MessageController.AddMessage("*chomp* *snrghf*");
            MessageController.AddMessage("I need more than that! STILL HUNGRY");
        } else if (GameOrchestrator.Instance.Bananas < 9)
        {
            MessageController.AddMessage("*shshhthtpp*");
            MessageController.AddMessage("MORE.");
            MessageController.AddMessage("BANANA.");
        } else if (GameOrchestrator.Instance.Bananas < 12)
        {
            MessageController.AddMessage("OMNOMNOMNOMNOM");
            MessageController.AddMessage("BANANA FEW MORE PLEASE");
        } else
        {
            MessageController.AddMessage("*gurp*");
            MessageController.AddMessage("ahhhhh~~");
            MessageController.AddMessage("That really hit the spot. Thank ya.");
            MessageController.AddMessage("My great uncle's grandma's friend's dog's wife's friend's great great granddaughter taught me this song.");
            MessageController.AddMessage("She always seemed to be moving pretty quick.");
            MessageController.AddMessage("You learned the SLOW JIG!");
            GameOrchestrator.Instance.HasSlowJig = true;
            MessageController.AddMessage("Now you can slow down time!");

        }
        
    }
}
