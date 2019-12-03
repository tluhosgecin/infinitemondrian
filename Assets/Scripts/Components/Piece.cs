using System.Collections.Generic;
using UnityEngine;

public class PieceData
{
    public int X = 0;
    public int Y = 0;
    public int W = 0;
    public int H = 0;
    public int I = 0;
    public int E = 0;
    public int V = 0;
    public int S = 0;
    public int P = 0;
    public int G = 0;
    public int L = 0;
    public int A = 0;

    public PieceData(int x, int y, int w, int h, int i, int e, int v, int s, int p, int g, int l, int a)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        I = i;
        E = e;
        V = v;
        S = s;
        P = p;
        G = g;
        L = l;
        A = a;
    }
}

public class Piece : MonoBehaviour
{
    public delegate void  Response(Piece data);
    public static   event Response OnEnter;
    public static   event Response OnLeave;
    
    [Header("Component")]
    public Renderer Renderer;

    [Header("Transform")]
    public int   X    = 0;
    public int   Y    = 0;
    public int   W    = 0;
    public int   H    = 0;
    public int   Grid = 20;
    public float Size = 1f;

    [Header("Color")]
    public List<Color> ColorList;
    public int         Initial = 0;
    public int         Elected = 0;

    [Header("Base")]
    public int Valid = 0;
    public int State = 0;

    [Header("Data")]
    public int Price    = 0;
    public int Group    = 0;
    public int Latitude = 0;
    public int Altitude = 0;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        if (OnEnter != null && Valid == 1)
        {
            OnEnter(this);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        if (OnLeave != null && Valid == 1)
        {
            OnLeave(this);
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

    public void SetBase(int initial, int elected, int z)
    {
        Initial = initial;
        Elected = elected;

        if (ColorList == null || ColorList.Count <= Initial)
        {
            return;
        }

        Renderer.material.SetColor("_BaseColor", ColorList[Initial]);
    }

    public void SetNext()
    {
        if (ColorList == null || ColorList.Count <= Elected)
        {
            return;
        }

        Renderer.material.SetColor("_BaseColor", ColorList[Elected]);
    }

    public void SetData(int price, int group, int latitude, int altitude)
    {
        Price    = price;
        Group    = group;
        Latitude = latitude;
        Altitude = altitude;
    }

    public void SetRoot(int valid, int state)
    {
        Valid = valid;
        State = state;

        transform.tag = (Valid == 1) ? "Piece" : "Untagged";
    }
}