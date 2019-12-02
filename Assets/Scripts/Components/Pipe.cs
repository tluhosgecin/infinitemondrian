using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("Component")]
    public List<Renderer> RendererList;
    
    public void SetPlane(int index, Color color)
    {
        if (RendererList == null || RendererList.Count <= index)
        {
            return;
        }
        
        RendererList[index].material.SetColor("_BaseColor", color);
    }

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
}