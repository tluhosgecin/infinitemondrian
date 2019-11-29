using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Color Color = new Color(0, 0, 0, 1);

    void Awake()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color);
    }

    void Update()
    {
        
    }
}