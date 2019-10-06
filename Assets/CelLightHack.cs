using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelLightHack : MonoBehaviour
{
    private new Transform light;
    
    void Start()
    {
        light = GetComponent<Transform>();
    }

    void Update()
    {
        Shader.SetGlobalVector("_CelLightDirection", -transform.forward);
    }
}
