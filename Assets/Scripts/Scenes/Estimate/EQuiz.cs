using System.Collections.Generic;
using UnityEngine;

public class EPieceData
{
    public int  X = 0;
    public int  Y = 0;
    public int  W = 1;
    public int  H = 1;
    public int  P = 0;
    public int  I = 0;
    public int  A = 0;
    public int  B = 0;
    public bool V = false;
    public bool S = false;

    public EPieceData(int x, int y, int w, int h, int p, int i, int a, int b, bool v, bool s)
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

public class EQuiz : MonoBehaviour
{
    public static List<EPieceData>[] QuizList = new List<EPieceData>[3]
    {
        new List<EPieceData>
        {
            new EPieceData(3,   3,  6, 6, 36, 1, 2, 5, true,  true),
            new EPieceData(14,  5,  4, 7, 28, 2, 2, 8, true,  false),
            new EPieceData(4,  15, 10, 3, 30, 3, 2, 7, true,  false),
            new EPieceData(10,  7,  1, 2,  0, 0, 0, 0, false, false),
            new EPieceData(3,  10,  2, 1,  0, 0, 0, 0, false, false),
            new EPieceData(14,  3,  2, 1,  0, 0, 0, 0, false, false),
            new EPieceData(12, 10,  1, 2,  0, 0, 0, 0, false, false),
            new EPieceData(15, 15,  1, 2,  0, 0, 0, 0, false, false),
            new EPieceData(12, 19,  2, 1,  0, 0, 0, 0, false, false)
        },
        new List<EPieceData>
        {
            new EPieceData(3,   3, 16,  2, 32, 1, 2, 5, true,  false),
            new EPieceData(12,  7,  7,  8, 56, 2, 2, 8, true,  false),
            new EPieceData(3,   7,  5, 12, 60, 3, 2, 7, true,  true),
            new EPieceData(3,   1,  2,  1,  0, 0, 0, 0, false, false),
            new EPieceData(1,   3,  1,  2,  0, 0, 0, 0, false, false),
            new EPieceData(10, 13,  1,  2,  0, 0, 0, 0, false, false),
            new EPieceData(12, 16,  2,  1,  0, 0, 0, 0, false, false),
            new EPieceData(9,   7,  1,  2,  0, 0, 0, 0, false, false),
            new EPieceData(1,  17,  1,  2,  0, 0, 0, 0, false, false)
        },
        new List<EPieceData>
        {
            new EPieceData(10,  3,  5,  4, 32, 1, 2, 8, true,  false),
            new EPieceData(7,   7,  4,  3, 32, 1, 2, 8, true,  false),
            new EPieceData(2,   7,  2, 10, 36, 3, 2, 7, true,  true),
            new EPieceData(2,  17,  8,  2, 36, 3, 2, 7, true,  true),
            new EPieceData(14, 11,  4,  7, 28, 2, 2, 5, true,  false),
            new EPieceData(10,  1,  2,  1,  0, 0, 0, 0, false, false),
            new EPieceData(16,  3,  1,  2,  0, 0, 0, 0, false, false),
            new EPieceData(2,   5,  2,  1,  0, 0, 0, 0, false, false),
            new EPieceData(5,   7,  1,  2,  0, 0, 0, 0, false, false),
            new EPieceData(14,  9,  2,  1,  0, 0, 0, 0, false, false),
            new EPieceData(12,  11, 1,  2,  0, 0, 0, 0, false, false)
        },
    };
    
    [Header("Component")]
    public EPiece Reference;

    [Header("Piece")]
    public List<EPiece> PieceList;
    public int          Index = 0;

    void Awake()
    {
        if (QuizList.Length < Index)
        {
            return;
        }

        foreach (var PieceData in QuizList[Index])
        {
            EPiece Piece = Instantiate(Reference, new Vector3(0, 0, 0), Quaternion.identity);
            Piece.transform.parent = transform;

            PieceList.Add(Piece);

            Piece.SetCube(PieceData.X, PieceData.Y, PieceData.W, PieceData.H);
            Piece.SetType(PieceData.A, PieceData.B);
            Piece.SetData(PieceData.P, PieceData.I);
            Piece.SetBase(PieceData.V, PieceData.S);
        }
    }
}