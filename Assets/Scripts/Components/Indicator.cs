using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [Header("Component")]
    public UnityEngine.UI.RawImage ILatitude;
    public UnityEngine.UI.RawImage IAltitude;
    public UnityEngine.UI.Text     TLatitude;
    public UnityEngine.UI.Text     TAltitude;

    [Header("Data")]
    public bool Active = true;

    void OnEnable()
    {
        Player.OnPoint += Transition;
    }

    void OnDisable()
    {
        Player.OnPoint -= Transition;
    }

    void Start()
    {
        TLatitude.text = "0";
        TAltitude.text = "0";

        ILatitude.gameObject.SetActive(false);
        IAltitude.gameObject.SetActive(false);
    }
    
    void Transition(bool valid, int latitude, int altitude)
    {
        if (valid == false)
        {
            ILatitude.gameObject.SetActive(false);
            IAltitude.gameObject.SetActive(false);

            return;
        }

        if (Active == true && Instance.Info == true)
        {
            if (latitude > 0)
            {
                TLatitude.text = latitude.ToString();
                ILatitude.gameObject.SetActive(true);
            }
            else
            {
                ILatitude.gameObject.SetActive(false);
            }

            if (altitude > 0)
            {
                TAltitude.text = altitude.ToString();
                IAltitude.gameObject.SetActive(true);
            }
            else
            {
                IAltitude.gameObject.SetActive(false);
            }
        }
    }
}
