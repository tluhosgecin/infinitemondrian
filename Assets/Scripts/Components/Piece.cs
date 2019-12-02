using System.Collections.Generic;
using UnityEngine;

public class PieceData
{
    public int X = 0;
    public int Y = 0;
    public int W = 1;
    public int H = 1;
    public int P = 0;
    public int I = 0;
    public int A = 0;
    public int B = 0;
    public int V = 0;
    public int S = 0;

    public PieceData(int x, int y, int w, int h, int p, int i, int a, int b, int v, int s)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        P = p;
        I = i;
        A = a;
        B = b;
        V = v;
        S = s;
    }
}

public class Piece : MonoBehaviour
{
    public delegate void  Response(Piece target);
    public static   event Response OnResponse;

    [Header("Component")]
    public Renderer Renderer;

    [Header("Color")]
    public List<Color> ColorList;
    public int         A = 0;
    public int         B = 0;
    
    [Header("Transform")]
    public int   X    = 0;
    public int   Y    = 0;
    public int   W    = 0;
    public int   H    = 0;
    public int   Grid = 20;
    public float Size = 1f;

    [Header("Data")]
    public int Price = 0;
    public int Index = 0;
    public int Valid = 0;
    public int State = 0;

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        if (OnResponse != null && Valid == 1)
        {
            OnResponse(this);
        }
    }
    
    public void SetCube(int x, int y, int w, int h)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        
        var RX = +1;
        var RY = -1;

        var NX = ((((W * (Size / Grid)) / 2) + (X * (Size / Grid))) * RX) - 0.5f;
        var NY = ((((H * (Size / Grid)) / 2) + (Y * (Size / Grid))) * RY) + 0.5f;

        var NW = ((Size / Grid) * W);
        var NH = ((Size / Grid) * H);

        transform.localPosition = new Vector3(NX, NY, 0.1f);
        transform.localScale    = new Vector3(NW, NH, 0.1f);
    }

    public void SetType(int a, int b)
    {
        A = a;
        B = b;

        if (ColorList == null || ColorList.Count <= A)
        {
            return;
        }

        Renderer.material.SetColor("_BaseColor", ColorList[A]);
    }

    public void SetNext()
    {
        if (ColorList == null || ColorList.Count <= B)
        {
            return;
        }

        Renderer.material.SetColor("_BaseColor", ColorList[B]);
    }

    public void SetData(int price, int index)
    {
        Price = price;
        Index = index;
    }

    public void SetBase(int valid, int state)
    {
        Valid = valid;
        State = state;

        transform.tag = (Valid == 1) ? "Piece" : "Untagged";
    }
}