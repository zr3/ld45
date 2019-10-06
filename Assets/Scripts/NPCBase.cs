using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    private void Awake()
    {
        if (GameOrchestrator.Instance.FestivalActive)
        {
            foreach(var watcher in GetComponentsInChildren<WatchAwareness>())
            {
                if (watcher.gameObject.name.Equals("Awareness"))
                {
                    watcher.gameObject.SetActive(false);
                } else
                {
                    watcher.GetComponent<SphereCollider>().radius = 2;
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (GameOrchestrator.Instance)
            GameOrchestrator.Instance.UnfocusCamera();
    }
}
