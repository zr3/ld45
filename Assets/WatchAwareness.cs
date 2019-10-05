using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAwareness : MonoBehaviour
{
    public string MessageToSend;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SendMessageUpwards(MessageToSend, SendMessageOptions.DontRequireReceiver);
    }
}
