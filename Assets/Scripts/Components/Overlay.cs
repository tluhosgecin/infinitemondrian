using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    [Header("Component")]
    public Fade       Fade;
    public GameObject Countdown;
    public GameObject Interface;
    public GameObject Cessation;

    [Header("Countdown")]
    public List<Texture2D>         TextureList;
    public UnityEngine.UI.RawImage Image;
    public int                     Index  = 0;
    public float                   Count  = 1;
    public float                   Timer  = 0;
    public bool                    Active = true;

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
        Button.OnAction += Conclusion;
        Tunnel.OnFinish += Transition;
    }

    void OnDisable()
    {
        Button.OnAction -= Conclusion;
        Tunnel.OnFinish -= Transition;
    }
    
    void Start()
    {
        if (TextureList.Count > Index)
        {
            Image.texture = TextureList[Index];
            Image.SetNativeSize();
            Index += 1;
        }

        Countdown.SetActive(true);
        Interface.SetActive(false);
        Cessation.SetActive(false);
    }

    void Update()
    {
        if (Active == true)
        {
            if (TextureList.Count >= Index && Timer < Count)
            {
                Timer += Time.deltaTime;

                if (Timer >= Count)
                {
                    if (TextureList.Count > Index)
                    {
                        Image.texture = TextureList[Index];
                        Image.SetNativeSize();
                    }

                    Timer = 0f;
                    Index += 1;
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
        Point.text = "Lives: " + Instance.Lives.ToString();
        Score.text = "Score: " + Instance.Score.ToString();

        Feedback.text  = (result == true) ? PositiveMessage : NegativeMessage;
        Feedback.color = (result == true) ? PositiveColor   : NegativeColor;

        Countdown.SetActive(false);
        Interface.SetActive(false);
        Cessation.SetActive(true);
    }
}