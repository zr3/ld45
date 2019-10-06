using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNorthEldritch : MonoBehaviour
{
    public bool IsNorth;
    void AwareOfPlayer()
    {
        MessageController.AddMessage(".*&.*.%.*.%-**&.*.*&.*.%.*.%-**&.*.*&.*.%.*.%-**&.*");
    }

    void TalkToPlayer()
    {
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
