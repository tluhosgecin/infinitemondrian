using System.Collections.Generic;
using UnityEngine;

public enum EPieceType
{
    Black  = 0,
    White  = 1,
    Gray   = 2,
    Red    = 3,
    Green  = 4,
    Blue   = 5,
    Yellow = 6,
    Pink   = 7,
    Orange = 8
}

public class EPiece : MonoBehaviour
{
    public delegate void  Answer(EPiece piece);
    public static   event Answer OnAnswer;

    private static int   Grid = 20;
    private static float Size = 1f;
    
    [Header("Component")]
    public Renderer Renderer;

    [Header("Data")]
    public int  Price = 0;
    public int  Index = 0;
    public bool Valid = false;
    public bool State = false;

    [Header("Color")]
    public List<Material> List;
    public int            A = 0;
    public int            B = 0;
    
    [Header("Transform")]
    public int X = 0;
    public int Y = 0;
    public int W = 0;
    public int H = 0;

    void OnTriggerEnter(Collider collider)
    {
        if (OnAnswer != null && Valid == true)
        {
            OnAnswer(this);
        }
    }
    
    public void SetCube(int x, int y, int w, int h)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        
        var NX = ((((W * (Size / Grid)) / 2) + (X * (Size / Grid))) * (+1)) - 0.5f;
        var NY = ((((H * (Size / Grid)) / 2) + (Y * (Size / Grid))) * (-1)) + 0.5f;

        var NW = ((Size / Grid) * W);
        var NH = ((Size / Grid) * H);

        transform.localPosition = new Vector3(NX, NY, 0.1f);
        transform.localScale    = new Vector3(NW, NH, 0.1f);
    }

    public void SetType(int a, int b)
    {
        A = a;
        B = b;

        if (List == null)
        {
            return;
        }

        Renderer.material = List[A];
    }

    public void SetNext()
    {
        if (List == null)
        {
            return;
        }

        Renderer.material = List[B];
    }

    public void SetData(int price, int index)
    {
        Price = price;
        Index = index;
    }

    public void SetBase(bool valid, bool state)
    {
        Valid = valid;
        State = state;
    }
}