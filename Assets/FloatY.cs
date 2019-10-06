using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatY : MonoBehaviour
{
    public static float WaveFrequency = 1;
    public static float WaveHeight = 0.25f;

    public float Offset = 0.4f;

    private new Transform transform;
    
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            WaveSurface,
            transform.position.z
        );
    }

    public float WaveSurface => Mathf.Sin((transform.position.x * WaveFrequency) + Time.time) * WaveHeight + Offset;
}
