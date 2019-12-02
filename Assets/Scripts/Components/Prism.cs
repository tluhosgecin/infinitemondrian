using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    [Header("Component")]
    public Renderer Renderer;

    [Header("Color")]
    public Color A;
    public Color B;
    public float Current  = 0f;
    public float Duration = 1f;

    [Header("Movement")]
    public Vector3 Speed;
    
    void Update()
    {
        if (Current < Duration)
        {
            Current += Time.deltaTime;
            
            Renderer.material.SetColor("_BaseColor", Ease(Current, A, (B - A), Duration));

            if (Current >= Duration)
            {
                Current = Duration;
            }
        }
        
        transform.Rotate(Speed * Time.deltaTime);
    }

    Color Ease(float time, Color begin, Color change, float duration)
    {
        return (change * time / duration + begin);
    }
}