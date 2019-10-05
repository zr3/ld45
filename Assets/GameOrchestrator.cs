using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestrator : MonoBehaviour
{
    void Start()
    {
        MessageController.AddMessage("test message");
    }
}
