using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePhysic : MonoBehaviour
{
    public static WavePhysic wavePhysic;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    private void Awake()
    {
        if (wavePhysic == null)
        {
            wavePhysic = this;
        }
        else if (wavePhysic != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
