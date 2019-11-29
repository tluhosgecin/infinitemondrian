using System.Collections.Generic;
using UnityEngine;

public class ETunnel : MonoBehaviour
{
    private readonly Vector3 Base = new Vector3(0f, 0f,  0f);
    private readonly Vector3 Zero = new Vector3(0f, 0f, 13f);
    private readonly Vector3 Root = new Vector3(0f, 0f, -1f);
    
    private EQuiz Quiz  = null;
    private int   Index = 0;

    public delegate void  Conclusion(bool result, int health, int score);
    public static   event Conclusion OnConclusion;

    public static int  Health = 5;
    public static int  Score  = 0;
    public static bool Active = false;

    [Header("Component")]
    public Transform   Puzzle;
    public List<EQuiz> QuizList;
    public List<EPipe> PipeList;

    [Header("Movement")]
    public float Speed = 2.5f;
    public float Surge = 3f;
    public float Timer = 0f;

    [Header("Transition")]
    public float Duration = 0.5f;
    public float Current  = 0f;
    public bool  Feedback = false;
    public bool  Accuracy = false;
    
    void OnEnable()
    {
        EPiece.OnAnswer += Transition;
    }

    void OnDisable()
    {
        EPiece.OnAnswer -= Transition;
    }

    void Start()
    {
        Health = 5;
        Score  = 0;
        Active = false;
    }

    void Update()
    {
        if (Active == true)
        {
            Timer = (Timer < Surge) ? (Timer + Time.deltaTime) : Surge;
            
            if (transform.position.z <= -1f)
            {
                var Target = PipeList[0];
                
                foreach (var Pipe in PipeList)
                {
                    if (Pipe.transform == Target.transform)
                    {
                        Pipe.transform.position = Zero;
                    }
                    else
                    {
                        Pipe.transform.position += Root;
                    }
                }
                
                PipeList.Add(Target);
                PipeList.RemoveAt(0);

                transform.position = Base;
            }

            transform.position += (Root * Time.deltaTime * Timer * (Speed / Surge));

            if (Quiz == null && QuizList.Count > Index)
            {
                Quiz                         = QuizList[Index++];
                Quiz.transform.parent        = PipeList[PipeList.Count - 1].transform;
                Quiz.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
            
            if (Feedback == true)
            {
                Current += Time.deltaTime;
                
                var R = 1f;
                var G = 1f;
                var B = 1f;
                
                if (Accuracy == true)
                {
                    if (Current < (Duration / 2))
                    {
                        R = Ease(Current, 1f, (0f    - 1f), (Duration / 2));
                        G = Ease(Current, 1f, (0.60f - 1f), (Duration / 2));
                        B = Ease(Current, 1f, (0.13f - 1f), (Duration / 2));
                    }
                    else
                    {
                        R = Ease((Current - (Duration / 2)), 0f,    (1f -    0f), (Duration / 2));
                        G = Ease((Current - (Duration / 2)), 0.60f, (1f - 0.60f), (Duration / 2));
                        B = Ease((Current - (Duration / 2)), 0.13f, (1f - 0.13f), (Duration / 2));
                    }
                }
                else
                {
                    if (Current < (Duration / 2))
                    {
                        R = Ease(Current, 1f, (0.85f - 1f), (Duration / 2));
                        G = Ease(Current, 1f, (0f    - 1f), (Duration / 2));
                        B = Ease(Current, 1f, (0f    - 1f), (Duration / 2));
                    }
                    else
                    {
                        R = Ease((Current - (Duration / 2)), 0.85f, (1f - 0.85f), (Duration / 2));
                        G = Ease((Current - (Duration / 2)), 0f,    (1f -    0f), (Duration / 2));
                        B = Ease((Current - (Duration / 2)), 0f,    (1f -    0f), (Duration / 2));
                    }
                }
                
                foreach (var Pipe in PipeList)
                {
                    Pipe.SetState(new Color(R, G, B));
                }

                if (Current >= Duration)
                {
                    foreach (var Pipe in PipeList)
                    {
                        Pipe.SetState(new Color(1, 1, 1));
                    }

                    Current  = 0f;
                    Feedback = false;
                }
            }
        }
        else
        {

            Timer = (Timer > 0) ? (Timer - Time.deltaTime) : 0;
            
            if (transform.position.z <= -1f)
            {
                var Target = PipeList[0];
                
                foreach (var Pipe in PipeList)
                {
                    if (Pipe.transform == Target.transform)
                    {
                        Pipe.transform.position = Zero;
                    }
                    else
                    {
                        Pipe.transform.position += Root;
                    }
                }
                
                PipeList.Add(Target);
                PipeList.RemoveAt(0);

                transform.position = Base;
            }

            transform.position += (Root * Time.deltaTime * Timer * (Speed / Surge));
        }
    }

    void Transition(EPiece piece)
    {
        if (Active == false)
        {
            return;
        }

        Feedback = true;
        Accuracy = piece.State;

        if (Accuracy == true)
        {
            foreach (var Piece in Quiz.PieceList)
            {
                if (Piece.Index == piece.Index)
                {
                    Piece.SetBase(false, false);
                    Piece.SetNext();
                }
            }
            
            EPiece Value = null;
            
            foreach (var Piece in Quiz.PieceList)
            {
                if (Piece.Valid == true && Piece.State == false)
                {
                    if (Value == null)
                    {
                        Value = Piece;
                    }
                    else
                    {
                        if (Piece.Price > Value.Price)
                        {
                            Value = Piece;
                        }
                    }
                }
            }

            if (Value == null)
            {
                if (Quiz)
                {
                    Quiz.transform.parent        = Puzzle;
                    Quiz.transform.localPosition = new Vector3(0f, 0f, 0f);
                    Quiz                         = null;
                }

                Score++;

                if (Index == QuizList.Count)
                {
                    Active = false;

                    if (OnConclusion != null)
                    {
                        OnConclusion(true, Health, Score);
                    }
                }
            }
            else
            {
                foreach (var Piece in Quiz.PieceList)
                {
                    if (Piece.Index == Value.Index)
                    {
                        Piece.SetBase(true, true);
                    }
                }
            }
        }
        else
        {
            Health--;
            
            if (Health == 0)
            {
                Active = false;
                Score  = 0;

                if (OnConclusion != null)
                {
                    OnConclusion(false, Health, Score);
                }
            }
        }
    }

    float Ease(float time, float begin, float change, float duration)
    {
        return (change * time / duration + begin);
    }
}