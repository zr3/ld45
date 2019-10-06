using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNorthEldritch : NPCBase
{
    public bool IsNorth;
    void AwareOfPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage(".*&.*.%.*.%-**&.*.*&.*.%.*.%-**&.*.*&.*.%.*.%-**&.*");
    }

    void TalkToPlayer()
    {
        MessageController.SetLookTarget(transform);
        MessageController.AddMessage("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
        if (IsNorth)
        {
            GameOrchestrator.Instance.HasNorthEldritch = true;
        } else
        {
            GameOrchestrator.Instance.HasSouthEldritch = true;
        }
        Destroy(gameObject);
    }
}
