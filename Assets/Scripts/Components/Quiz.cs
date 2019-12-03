using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [Header("Component")]
    public Piece Reference;

    [Header("Data")]
    public List<Piece> PieceList;

    public void SetData(PieceData data)
    {
        /*
        *   Create Piece With Given Piece Data
        */
        Piece Piece = Instantiate(Reference, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Piece.transform.parent        = transform;
        Piece.transform.localPosition = new Vector3(0f, 0f, 0f);

        PieceList.Add(Piece);

        Piece.SetCube(data.X, data.Y, data.W, data.H);
        Piece.SetBase(data.I, data.E, 0);
        Piece.SetRoot(data.V, data.S);
        Piece.SetData(data.P, data.G, data.L, data.A);
    }
}