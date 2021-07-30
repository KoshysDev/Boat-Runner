using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoiseGenerator : MonoBehaviour
{
    public float power, scale, timeScale;
    private float _xOffset, _yOffset;

    private MeshFilter _meshFilter;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        GenerateNoise();
    }

    private void Update()
    {
        GenerateNoise();

        _xOffset += Time.deltaTime * timeScale;
        _yOffset += Time.deltaTime * timeScale;
    }

    private void GenerateNoise()
    {
        Vector3[] verticies = _meshFilter.mesh.vertices;

        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        _meshFilter.mesh.vertices = verticies;
    }

    private float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + _xOffset;
        float yCord = y * scale + _yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
