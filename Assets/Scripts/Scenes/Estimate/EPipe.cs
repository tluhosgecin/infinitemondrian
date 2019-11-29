using System.Collections.Generic;
using UnityEngine;

public enum EPlaneIndex
{
    Top    = 0,
    Right  = 1,
    Bottom = 2,
    Left   = 3,
}

public class EPipe : MonoBehaviour
{
    [Header("Component")]
    public List<Renderer> RendererList;
    
    public void SetState(Color color)
    {
        if (RendererList == null)
        {
            return;
        }
        
        foreach (var Renderer in RendererList)
        {
            Renderer.material.SetColor("_BaseColor", color);
        }
    }

    public void SetPlane(int index, Color color)
    {
        if (RendererList == null)
        {
            return;
        }
        
        RendererList[index].material.SetColor("_BaseColor", color);
    }
}