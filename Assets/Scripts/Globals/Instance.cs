using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    /*
    *   Level Data
    */
    public static string Level = "EA00";
    public static int    Point = 5;
    public static int    Score = 0;
    public static bool   Info  = false;
    public static bool   Ready = false;

    /*
    *   Piece Data
    */
    public static Dictionary<string, List<PieceData>[]> Puzzle = new Dictionary<string, List<PieceData>[]>()
    {
        /*
        *   Piece Data Of Estimate Area Level
        */
        ["EA00"] = new List<PieceData>[]
        {
            new List<PieceData>
            {
                new PieceData(3,   3,  6, 6, 36, 1, 2, 5, 1, 1),
                new PieceData(14,  5,  4, 7, 28, 2, 2, 8, 1, 0),
                new PieceData(4,  15, 10, 3, 30, 3, 2, 7, 1, 0),
                new PieceData(10,  7,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(3,  10,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  3,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 10,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(15, 15,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 19,  2, 1,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(3,   3, 16,  2, 32, 1, 2, 5, 1, 0),
                new PieceData(12,  7,  7,  8, 56, 2, 2, 8, 1, 0),
                new PieceData(3,   7,  5, 12, 60, 3, 2, 7, 1, 1),
                new PieceData(3,   1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(1,   3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(10, 13,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 16,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(9,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(1,  17,  1,  2,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(10,  3,  5,  4, 32, 1, 2, 8, 1, 0),
                new PieceData(7,   7,  4,  3, 32, 1, 2, 8, 1, 0),
                new PieceData(2,   7,  2, 10, 36, 3, 2, 7, 1, 1),
                new PieceData(2,  17,  8,  2, 36, 3, 2, 7, 1, 1),
                new PieceData(14, 11,  4,  7, 28, 2, 2, 5, 1, 0),
                new PieceData(10,  1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(16,  3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(2,   5,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(5,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  9,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(12,  11, 1,  2,  0, 0, 0, 0, 0, 0)
            }
        },

        /*
        *   Piece Data Of Estimate Perimeter Level
        */
        ["EP00"] = new List<PieceData>[]
        {
            new List<PieceData>
            {
                new PieceData(3,   3,  6, 6, 36, 1, 2, 5, 1, 1),
                new PieceData(14,  5,  4, 7, 28, 2, 2, 8, 1, 0),
                new PieceData(4,  15, 10, 3, 30, 3, 2, 7, 1, 0),
                new PieceData(10,  7,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(3,  10,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  3,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 10,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(15, 15,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 19,  2, 1,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(3,   3, 16,  2, 32, 1, 2, 5, 1, 0),
                new PieceData(12,  7,  7,  8, 56, 2, 2, 8, 1, 0),
                new PieceData(3,   7,  5, 12, 60, 3, 2, 7, 1, 1),
                new PieceData(3,   1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(1,   3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(10, 13,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 16,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(9,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(1,  17,  1,  2,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(10,  3,  5,  4, 32, 1, 2, 8, 1, 0),
                new PieceData(7,   7,  4,  3, 32, 1, 2, 8, 1, 0),
                new PieceData(2,   7,  2, 10, 36, 3, 2, 7, 1, 1),
                new PieceData(2,  17,  8,  2, 36, 3, 2, 7, 1, 1),
                new PieceData(14, 11,  4,  7, 28, 2, 2, 5, 1, 0),
                new PieceData(10,  1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(16,  3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(2,   5,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(5,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  9,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(12,  11, 1,  2,  0, 0, 0, 0, 0, 0)
            }
        },

        /*
        *   Piece Data Of Calculate Area Level
        */
        ["CA00"] = new List<PieceData>[]
        {
            new List<PieceData>
            {
                new PieceData(3,   3,  6, 6, 36, 1, 2, 5, 1, 1),
                new PieceData(14,  5,  4, 7, 28, 2, 2, 8, 1, 0),
                new PieceData(4,  15, 10, 3, 30, 3, 2, 7, 1, 0),
                new PieceData(10,  7,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(3,  10,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  3,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 10,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(15, 15,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 19,  2, 1,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(3,   3, 16,  2, 32, 1, 2, 5, 1, 0),
                new PieceData(12,  7,  7,  8, 56, 2, 2, 8, 1, 0),
                new PieceData(3,   7,  5, 12, 60, 3, 2, 7, 1, 1),
                new PieceData(3,   1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(1,   3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(10, 13,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 16,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(9,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(1,  17,  1,  2,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(10,  3,  5,  4, 32, 1, 2, 8, 1, 0),
                new PieceData(7,   7,  4,  3, 32, 1, 2, 8, 1, 0),
                new PieceData(2,   7,  2, 10, 36, 3, 2, 7, 1, 1),
                new PieceData(2,  17,  8,  2, 36, 3, 2, 7, 1, 1),
                new PieceData(14, 11,  4,  7, 28, 2, 2, 5, 1, 0),
                new PieceData(10,  1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(16,  3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(2,   5,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(5,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  9,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(12,  11, 1,  2,  0, 0, 0, 0, 0, 0)
            }
        },
        /*
        *   Piece Data Of Calculate Perimeter Level
        */
        ["CP00"] = new List<PieceData>[]
        {
            new List<PieceData>
            {
                new PieceData(3,   3,  6, 6, 36, 1, 2, 5, 1, 1),
                new PieceData(14,  5,  4, 7, 28, 2, 2, 8, 1, 0),
                new PieceData(4,  15, 10, 3, 30, 3, 2, 7, 1, 0),
                new PieceData(10,  7,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(3,  10,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  3,  2, 1,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 10,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(15, 15,  1, 2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 19,  2, 1,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(3,   3, 16,  2, 32, 1, 2, 5, 1, 0),
                new PieceData(12,  7,  7,  8, 56, 2, 2, 8, 1, 0),
                new PieceData(3,   7,  5, 12, 60, 3, 2, 7, 1, 1),
                new PieceData(3,   1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(1,   3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(10, 13,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(12, 16,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(9,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(1,  17,  1,  2,  0, 0, 0, 0, 0, 0)
            },
            new List<PieceData>
            {
                new PieceData(10,  3,  5,  4, 32, 1, 2, 8, 1, 0),
                new PieceData(7,   7,  4,  3, 32, 1, 2, 8, 1, 0),
                new PieceData(2,   7,  2, 10, 36, 3, 2, 7, 1, 1),
                new PieceData(2,  17,  8,  2, 36, 3, 2, 7, 1, 1),
                new PieceData(14, 11,  4,  7, 28, 2, 2, 5, 1, 0),
                new PieceData(10,  1,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(16,  3,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(2,   5,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(5,   7,  1,  2,  0, 0, 0, 0, 0, 0),
                new PieceData(14,  9,  2,  1,  0, 0, 0, 0, 0, 0),
                new PieceData(12,  11, 1,  2,  0, 0, 0, 0, 0, 0)
            }
        },
    };
}