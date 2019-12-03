using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("Component")]
    public Fade   Fade;
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Level4;
    public Button Return;

    void OnEnable()
    {
        Button.OnAction += Transition;
    }

    void OnDisable()
    {
        Button.OnAction -= Transition;
    }

    void Transition(Button target)
    {
        if (target == Level1)
        {
            Level1.Active = false;
            Level2.Active = false;
            Level3.Active = false;
            Level4.Active = false;
            Return.Active = false;

            Instance.Level = "EA00";
            Instance.Lives = 5;
            Instance.Score = 0;
            Instance.Info  = false;
            Instance.Ready = false;

            Fade.Index  = 4;
            Fade.Status = true;

            return;
        }

        if (target == Level2)
        {
            Level1.Active = false;
            Level2.Active = false;
            Level3.Active = false;
            Level4.Active = false;
            Return.Active = false;

            Instance.Level = "EP00";
            Instance.Lives = 5;
            Instance.Score = 0;
            Instance.Info  = false;
            Instance.Ready = false;
            
            Fade.Index  = 4;
            Fade.Status = true;

            return;
        }

        if (target == Level3)
        {
            Level1.Active = false;
            Level2.Active = false;
            Level3.Active = false;
            Level4.Active = false;
            Return.Active = false;

            Instance.Level = "CA00";
            Instance.Lives = 5;
            Instance.Score = 0;
            Instance.Info  = true;
            Instance.Ready = false;

            Fade.Index  = 4;
            Fade.Status = true;

            return;
        }

        if (target == Level4)
        {
            Level1.Active = false;
            Level2.Active = false;
            Level3.Active = false;
            Level4.Active = false;
            Return.Active = false;

            Instance.Level = "CP00";
            Instance.Lives = 5;
            Instance.Score = 0;
            Instance.Info  = true;
            Instance.Ready = false;

            Fade.Index  = 4;
            Fade.Status = true;

            return;
        }

        if (target == Return)
        {
            Level1.Active = false;
            Level2.Active = false;
            Level3.Active = false;
            Level4.Active = false;
            Return.Active = false;

            Fade.Index  = 2;
            Fade.Status = true;

            return;
        }
    }
}
