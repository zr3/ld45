using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAwareness : MonoBehaviour
{
    public string MessageToSend;
    public bool ReactToSong;

    bool touchingPlayer = false;

    private float lastTriggerTime;

    private void Start()
    {
        if (ReactToSong)
        {
            GameOrchestrator.Instance.RegisterForSongs(song =>
            {
                if (touchingPlayer)
                {
                    gameObject.SendMessageUpwards("SongPlayed", song, SendMessageOptions.DontRequireReceiver);
                }
            });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (lastTriggerTime < Time.time - 5)
                gameObject.SendMessageUpwards(MessageToSend, SendMessageOptions.DontRequireReceiver);
            touchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            touchingPlayer = false;
        }
    }
}
