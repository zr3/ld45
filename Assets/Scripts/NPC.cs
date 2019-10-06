using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void AwareOfPlayer() {
        // ui effect and animation
    }

    void TalkToPlayer()
    {
        MessageController.AddMessage("Hi! You must be new here.");
    }
}
