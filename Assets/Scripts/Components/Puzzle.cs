using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [Header("Component")]
    public Quiz Reference;
    
    [Header("Data")]
    public Quiz       Current;
    public int        Index = 0;
    public List<Quiz> QuizList;

    void Start()
    {
        if (Instance.Puzzle.ContainsKey(Instance.Level) == false)
        {
            return;
        }

        foreach (var Collection in Instance.Puzzle[Instance.Level])
        {
            /*
            *   Create 'Quiz' Objects To Store Pieces In It
            */
            Quiz Quiz = Instantiate(Reference, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Quiz.transform.parent        = transform;
            Quiz.transform.localPosition = new Vector3(0f, 0f, 0f);

            QuizList.Add(Quiz);

            foreach (var Data in Collection)
            {
                /*
                *   Pass Each Piece Data To The Quiz
                */
                Quiz.SetData(Data);
            }
        }
    }
}