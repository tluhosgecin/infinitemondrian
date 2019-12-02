using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [Header("Component")]
    public List<UnityEngine.UI.RawImage> List;

    [Header("Color")]
    public Color Restored;
    public Color Depleted;

    [Header("Data")]
    public int Value = 5;
    
    void Start()
    {
        Value = Instance.Point;

        foreach (var Image in List)
        {
            Image.color = Restored;
        }
    }
    
    void Update()
    {
        if (Value != Instance.Point)
        {
            Value = Instance.Point;

            foreach (var Image in List)
            {
                if (List.IndexOf(Image) >= Value)
                {
                    Image.color = Depleted;
                }
                else
                {
                    Image.color = Restored;
                }
            }
        }
    }
}
