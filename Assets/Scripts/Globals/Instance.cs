using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    /*
    *   Level Data
    */
    public static string Level = "EA00";
    public static int    Lives = 5;
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
                new PieceData(03, 03, 06, 06, 2, 5, 1, 1, 36, 1, 06, 06),
                new PieceData(14, 05, 04, 07, 2, 8, 1, 0, 28, 2, 04, 07),
                new PieceData(04, 15, 10, 03, 2, 7, 1, 0, 30, 3, 10, 03),
                new PieceData(10, 07, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(03, 10, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(14, 03, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(12, 10, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(15, 15, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(12, 19, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
            },
            new List<PieceData>
            {
                new PieceData(03, 03, 16, 02, 2, 5, 1, 0, 32, 1, 16, 02),
                new PieceData(12, 07, 07, 08, 2, 8, 1, 0, 56, 2, 07, 08),
                new PieceData(03, 07, 05, 12, 2, 7, 1, 1, 60, 3, 05, 12),
                new PieceData(03, 01, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(01, 03, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(10, 13, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(12, 16, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(09, 07, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(01, 17, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
            },
            new List<PieceData>
            {
                new PieceData(10, 03, 05, 04, 2, 8, 1, 0, 32, 1, 05, 04),
                new PieceData(07, 07, 04, 03, 2, 8, 1, 0, 32, 1, 04, 03),
                new PieceData(02, 07, 02, 10, 2, 7, 1, 1, 36, 2, 02, 10),
                new PieceData(02, 17, 08, 02, 2, 7, 1, 1, 36, 2, 08, 02),
                new PieceData(14, 11, 04, 07, 2, 5, 1, 0, 28, 3, 04, 07),
                new PieceData(10, 01, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(16, 03, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(02, 05, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(05, 07, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(14, 09, 02, 01, 0, 0, 0, 0, 00, 0, 00, 00),
                new PieceData(12, 11, 01, 02, 0, 0, 0, 0, 00, 0, 00, 00),
            }
        },

        /*
        *   Piece Data Of Estimate Perimeter Level
        */
        ["EP00"] = new List<PieceData>[]
        {
            new List<PieceData>
            {
                new PieceData(02, 01, 10, 01, 2, 3, 1, 0, 34, 1, 10, 07),
                new PieceData(02, 07, 10, 01, 2, 3, 1, 0, 34, 1, 10, 07),
                new PieceData(02, 02, 01, 05, 2, 3, 1, 0, 34, 1, 10, 07),
                new PieceData(11, 02, 01, 05, 2, 3, 1, 0, 34, 1, 10, 07),
                new PieceData(01, 10, 11, 01, 2, 6, 1, 0, 40, 2, 11, 09),
                new PieceData(01, 18, 11, 01, 2, 6, 1, 0, 40, 2, 11, 09),
                new PieceData(01, 11, 01, 07, 2, 6, 1, 0, 40, 2, 11, 09),
                new PieceData(11, 11, 01, 07, 2, 6, 1, 0, 40, 2, 11, 09),
                new PieceData(13, 01, 06, 01, 2, 5, 1, 1, 48, 3, 06, 18),
                new PieceData(13, 18, 06, 01, 2, 5, 1, 1, 48, 3, 06, 18),
                new PieceData(13, 02, 01, 16, 2, 5, 1, 1, 48, 3, 06, 18),
                new PieceData(18, 02, 01, 16, 2, 5, 1, 1, 48, 3, 06, 18),
            },
            new List<PieceData>
            {
                new PieceData(06, 01, 08, 01, 2, 5, 1, 0, 30, 1, 08, 07),
                new PieceData(06, 07, 08, 01, 2, 5, 1, 0, 30, 1, 08, 07),
                new PieceData(06, 02, 01, 05, 2, 5, 1, 0, 30, 1, 08, 07),
                new PieceData(13, 02, 01, 05, 2, 5, 1, 0, 30, 1, 08, 07),
                new PieceData(04, 09, 12, 01, 2, 6, 1, 0, 40, 2, 12, 05),
                new PieceData(04, 13, 12, 01, 2, 6, 1, 0, 40, 2, 12, 05),
                new PieceData(04, 10, 01, 03, 2, 6, 1, 0, 40, 2, 12, 05),
                new PieceData(15, 10, 01, 03, 2, 6, 1, 0, 40, 2, 12, 05),
                new PieceData(01, 16, 18, 01, 2, 3, 1, 1, 42, 3, 18, 03),
                new PieceData(01, 18, 18, 01, 2, 3, 1, 1, 42, 3, 18, 03),
                new PieceData(01, 17, 01, 01, 2, 3, 1, 1, 42, 3, 18, 03),
                new PieceData(18, 17, 01, 01, 2, 3, 1, 1, 42, 3, 18, 03),
            },
            new List<PieceData>
            {
                new PieceData(02, 01, 10, 01, 2, 5, 1, 0, 38, 1, 10, 09),
                new PieceData(02, 09, 10, 01, 2, 5, 1, 0, 38, 1, 10, 09),
                new PieceData(02, 02, 01, 07, 2, 5, 1, 0, 38, 1, 10, 09),
                new PieceData(11, 02, 01, 07, 2, 5, 1, 0, 38, 1, 10, 09),
                new PieceData(13, 01, 06, 01, 2, 6, 1, 0, 34, 2, 06, 11),
                new PieceData(13, 11, 06, 01, 2, 6, 1, 0, 34, 2, 06, 11),
                new PieceData(13, 02, 01, 09, 2, 6, 1, 0, 34, 2, 06, 11),
                new PieceData(18, 02, 01, 09, 2, 6, 1, 0, 34, 2, 06, 11),
                new PieceData(02, 13, 17, 01, 2, 3, 1, 1, 46, 3, 17, 06),
                new PieceData(02, 18, 17, 01, 2, 3, 1, 1, 46, 3, 17, 06),
                new PieceData(02, 14, 01, 04, 2, 3, 1, 1, 46, 3, 17, 06),
                new PieceData(18, 14, 01, 04, 2, 3, 1, 1, 46, 3, 17, 06),
            },
            new List<PieceData>
            {
                new PieceData(08, 02, 09, 01, 2, 5, 1, 1, 30, 1, 09, 06),
                new PieceData(08, 07, 09, 01, 2, 5, 1, 1, 30, 1, 09, 06),
                new PieceData(08, 03, 01, 04, 2, 5, 1, 1, 30, 1, 09, 06),
                new PieceData(16, 03, 01, 04, 2, 5, 1, 1, 30, 1, 09, 06),
                new PieceData(02, 05, 04, 01, 2, 3, 1, 0, 26, 2, 04, 09),
                new PieceData(02, 13, 04, 01, 2, 3, 1, 0, 26, 2, 04, 09),
                new PieceData(02, 06, 01, 07, 2, 3, 1, 0, 26, 2, 04, 09),
                new PieceData(05, 06, 01, 07, 2, 3, 1, 0, 26, 2, 04, 09),
                new PieceData(10, 12, 07, 01, 2, 6, 1, 0, 28, 3, 07, 07),
                new PieceData(10, 18, 07, 01, 2, 6, 1, 0, 28, 3, 07, 07),
                new PieceData(10, 13, 01, 05, 2, 6, 1, 0, 28, 3, 07, 07),
                new PieceData(16, 13, 01, 05, 2, 6, 1, 0, 28, 3, 07, 07),
            },
            new List<PieceData>
            {
                new PieceData(02, 00, 15, 01, 2, 5, 1, 0, 48, 1, 15, 09),
                new PieceData(02, 08, 15, 01, 2, 5, 1, 0, 48, 1, 15, 09),
                new PieceData(02, 01, 01, 07, 2, 5, 1, 0, 48, 1, 15, 09),
                new PieceData(16, 01, 01, 07, 2, 5, 1, 0, 48, 1, 15, 09),
                new PieceData(00, 03, 11, 01, 2, 6, 1, 0, 50, 2, 11, 14),
                new PieceData(00, 16, 11, 01, 2, 6, 1, 0, 50, 2, 11, 14),
                new PieceData(00, 04, 01, 12, 2, 6, 1, 0, 50, 2, 11, 14),
                new PieceData(10, 04, 01, 12, 2, 6, 1, 0, 50, 2, 11, 14),
                new PieceData(05, 06, 14, 01, 2, 3, 1, 1, 54, 3, 14, 13),
                new PieceData(05, 18, 14, 01, 2, 3, 1, 1, 54, 3, 14, 13),
                new PieceData(05, 07, 01, 11, 2, 3, 1, 1, 54, 3, 14, 13),
                new PieceData(18, 07, 01, 11, 2, 3, 1, 1, 54, 3, 14, 13),
            },
        },

        /*
        *   Piece Data Of Calculate Area Level
        */
        ["CA00"] = new List<PieceData>[]
        {
            
        },
        /*
        *   Piece Data Of Calculate Perimeter Level
        */
        ["CP00"] = new List<PieceData>[]
        {
            
        },
    };
}