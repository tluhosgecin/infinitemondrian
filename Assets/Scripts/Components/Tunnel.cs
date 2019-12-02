using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public delegate void  Conclusion(bool result);
    public static   event Conclusion OnConclusion;

    private Color   Base = new Color(0f, 0f, 0f);
    private Vector3 Root = new Vector3(0f, 0f, 0f);
    
    [Header("Component")]
    public Puzzle Puzzle;

    [Header("Movement")]
    public float Speed = 2f;
    public float Surge = 1f;
    public float Timer = 0f;

    [Header("Animation")]
    public Color White;
    public Color Red;
    public Color Green;
    public bool  Feedback = false;
    public int   Accuracy = 0;
    public float Duration = 0.5f;
    public float Current  = 0f;
    
    [Header("Data")]
    public List<Pipe> PipeList;
    
    void OnEnable()
    {
        Piece.OnResponse += Response;
    }

    void OnDisable()
    {
        Piece.OnResponse -= Response;
    }
    
    void Update()
    {
        if (Instance.Ready == true)
        {
            /*
            *   Calculate The Timer For Movement
            */
            Timer = (Timer < Surge) ? (Timer + Time.deltaTime) : Surge;

            /*
            *   Assign The Next Quiz From Quiz List
            */
            if (Puzzle.Current == null && Puzzle.QuizList.Count > Puzzle.Index)
            {
                Puzzle.Current                         = Puzzle.QuizList[Puzzle.Index++];
                Puzzle.Current.transform.parent        = PipeList[PipeList.Count - 1].transform;
                Puzzle.Current.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
            
            /*
            *   Flashing Tunnel Animation Feedback
            */
            if (Feedback == true)
            {
                Current += Time.deltaTime;
                
                if (Current < Duration)
                {
                    if (Accuracy == 1)
                    {
                        if (Current < (Duration / 2))
                        {
                            Base = Ease(Current, White, (Green - White), (Duration / 2));
                        }
                        else
                        {
                            Base = Ease((Current - (Duration / 2)), Green, (White - Green), (Duration / 2));
                        }
                    }
                    else
                    {
                        if (Current < (Duration / 2))
                        {
                            Base = Ease(Current, White, (Red - White), (Duration / 2));
                        }
                        else
                        {
                            Base = Ease((Current - (Duration / 2)), Red, (White - Red), (Duration / 2));
                        }
                    }
                    
                    foreach (var Pipe in PipeList)
                    {
                        Pipe.SetState(Base);
                    }
                }
                else
                {
                    foreach (var Pipe in PipeList)
                    {
                        Pipe.SetState(White);
                    }

                    Current  = 0f;
                    Feedback = false;
                }
            }
        }
        else
        {
            /*
            *   Calculate The Timer For Movement
            */
            Timer = (Timer > 0) ? (Timer - Time.deltaTime) : 0;
        }

        if (transform.position.z <= -1f)
        {
            /*
            *   Reset The Tunnel Position
            */
            Root.x = 0f;
            Root.y = 0f;
            Root.z = 0f;
            
            transform.position = Root;

            /*
            *   Order Each Pipe And Assign Pipe Positions
            */
            var Object = PipeList[0];
            
            foreach (var Pipe in PipeList)
            {
                if (Pipe == Object)
                {
                    Root.x = 0f;
                    Root.y = 0f;
                    Root.z = PipeList.Count - 1;

                    Pipe.transform.position = Root;
                }
                else
                {
                    Root.x = 0f;
                    Root.y = 0f;
                    Root.z = -1f;

                    Pipe.transform.position += Root;
                }
            }
            
            PipeList.Add(Object);
            PipeList.RemoveAt(0);
        }
        
        /*
        *   Calculate Tunnel Movement Based On The Timer Value
        */
        Root.x = 0f;
        Root.y = 0f;
        Root.z = -1f;

        transform.position += (Root * Time.deltaTime * Timer * (Speed / Surge));
    }
    
    void Response(Piece target)
    {
        Feedback = true;
        Accuracy = target.State;

        if (Accuracy == 1)
        {
            Instance.Score += 1;
            
            /*
            *   Remove The Solved Piece From Quiz
            */
            foreach (var Piece in Puzzle.Current.PieceList)
            {
                if (Piece.Index == target.Index)
                {
                    Piece.SetBase(0, 0);
                    Piece.SetNext();
                }
            }
            
            /*
            *   Find And Assign Next Correct Piece
            */
            Piece Object = null;
            
            foreach (var Piece in Puzzle.Current.PieceList)
            {
                if (Piece.Valid == 1 && Piece.State == 0)
                {
                    if (Object == null)
                    {
                        Object = Piece;
                    }
                    else
                    {
                        if (Piece.Price > Object.Price)
                        {
                            Object = Piece;
                        }
                    }
                }
            }

            if (Object == null)
            {
                /*
                *   Remove The Solved Quiz From Tunnel
                */
                if (Puzzle.Current != null)
                {
                    Puzzle.Current.transform.parent        = Puzzle.transform;
                    Puzzle.Current.transform.localPosition = new Vector3(0f, 0f, 0f);
                    Puzzle.Current                         = null;
                }

                /*
                *   End Of The Level (Positive)
                */
                if (Puzzle.Index == Puzzle.QuizList.Count)
                {
                    Instance.Ready = false;

                    if (OnConclusion != null)
                    {
                        OnConclusion(true);
                    }
                }
            }
            else
            {
                /*
                *   Assign The Next Linked Pieces To Be Solved
                */
                foreach (var Piece in Puzzle.Current.PieceList)
                {
                    if (Piece.Index == Object.Index)
                    {
                        Piece.SetBase(1, 1);
                    }
                }
            }
        }
        else
        {
            /*
            *   Deduct One Point From The Player
            */
            Instance.Point -= 1;
            
            /*
            *   End Of The Level (Negative)
            */
            if (Instance.Point == 0)
            {
                Instance.Ready = false;
                
                if (OnConclusion != null)
                {
                    OnConclusion(false);
                }
            }
        }
    }
    
    Color Ease(float time, Color begin, Color change, float duration)
    {
        return (change * time / duration + begin);
    }
}