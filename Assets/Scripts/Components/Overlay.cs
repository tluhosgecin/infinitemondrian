using UnityEngine;

public class Overlay : MonoBehaviour
{
    [Header("Component")]
    public Fade       Fade;
    public GameObject Countdown;
    public GameObject Interface;
    public GameObject Cessation;

    [Header("Countdown")]
    public UnityEngine.UI.Text Count;
    public float               Timer  = 5;
    public bool                Active = true;

    [Header("Cessation")]
    public UnityEngine.UI.Text Feedback;
    public UnityEngine.UI.Text Point;
    public UnityEngine.UI.Text Score;
    public Button              Continue;
    public Color               PositiveColor;
    public Color               NegativeColor;
    public string              PositiveMessage;
    public string              NegativeMessage;
    
    void OnEnable()
    {
        Button.OnAction     += Conclusion;
        Tunnel.OnConclusion += Transition;
    }

    void OnDisable()
    {
        Button.OnAction     -= Conclusion;
        Tunnel.OnConclusion -= Transition;
    }
    
    void Start()
    {
        Countdown.SetActive(true);
        Interface.SetActive(false);
        Cessation.SetActive(false);
    }

    void Update()
    {
        if (Active == true)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;

                if (Timer > 0)
                {
                    Count.text = Mathf.Ceil(Timer).ToString();
                }
            }
            else
            {
                Instance.Ready = true;

                Interface.SetActive(true);
                Countdown.SetActive(false);
                Cessation.SetActive(false);

                Active = false;
            }
        }
    }

    void Conclusion(Button target)
    {
        if (target == Continue)
        {
            Fade.Status     = true;
            Continue.Active = false;
        }
    }

    void Transition(bool result)
    {
        Point.text = "Lives: " + Instance.Point.ToString();
        Score.text = "Score: " + Instance.Score.ToString();

        Feedback.text  = (result == true) ? PositiveMessage : NegativeMessage;
        Feedback.color = (result == true) ? PositiveColor   : NegativeColor;

        Countdown.SetActive(false);
        Interface.SetActive(false);
        Cessation.SetActive(true);
    }
}