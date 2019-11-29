using UnityEngine;

public class EInterface : MonoBehaviour
{
    private bool Active = false;

    private UnityEngine.UI.Text CountdownText;
    private UnityEngine.UI.Text ConclusionText;

    [Header("Component")]
    public GameObject Crosshair;
    public GameObject Countdown;
    public GameObject Conclusion;

    [Header("Data")]
    public float Timer = 5;

    void OnEnable()
    {
        ETunnel.OnConclusion += Transition;
    }

    void OnDisable()
    {
        ETunnel.OnConclusion -= Transition;
    }
    
    void Start()
    {
        CountdownText  = Countdown.GetComponent<UnityEngine.UI.Text>();
        ConclusionText = Conclusion.GetComponent<UnityEngine.UI.Text>();

        Crosshair.SetActive(false);
        Countdown.SetActive(true);
        Conclusion.SetActive(false);
    }

    void Update()
    {
        if (Active == false)
        {
            if (Timer > 0)
            {
                Timer              -= Time.deltaTime;
                CountdownText.text  = Mathf.Ceil(Timer).ToString();
            }
            else
            {
                Crosshair.SetActive(true);
                Countdown.SetActive(false);

                ETunnel.Active = Active = true;
            }
        }
    }

    void Transition(bool result, int health, int score)
    {
        Crosshair.SetActive(false);
        Countdown.SetActive(false);
        Conclusion.SetActive(true);

        ConclusionText.text  = (result) ? "Congratulations"          : "Game Over";
        ConclusionText.color = (result) ? new Color(0f, 0.6f, 0.15f) : new Color(0.85f, 0f, 0f);
    }
}
