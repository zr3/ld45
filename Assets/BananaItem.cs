using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaItem : MonoBehaviour
{
    void AwareOfPlayer()
    {

    }

    void ItemActivate()
    {
        GameOrchestrator.Instance.Bananas++;
        Destroy(gameObject);
    }
}
