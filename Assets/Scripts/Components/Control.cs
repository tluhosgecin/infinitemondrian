using UnityEngine;

public class Control : MonoBehaviour
{
    [Header("Component")]
    public Fade   Fade;
    public Button Play;
    public Button Credits;
    public Button Exit;

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
        if (target == Play)
        {
            Play.Active    = false;
            Credits.Active = false;
            Exit.Active    = false;

            Fade.Index  = 4;
            Fade.Status = true;

            return;
        }

        if (target == Credits)
        {
            Play.Active    = false;
            Credits.Active = false;
            Exit.Active    = false;

            Fade.Index  = 1;
            Fade.Status = true;

            return;
        }

        if (target == Exit)
        {
            Application.Quit();
        }
    }
}