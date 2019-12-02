using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [Header("Component")]
    public UnityEngine.UI.RawImage ImageH;
    public UnityEngine.UI.RawImage ImageW;
    public UnityEngine.UI.Text     TextH;
    public UnityEngine.UI.Text     TextW;

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
        TextH.text = "0";
        TextW.text = "0";

        ImageH.gameObject.SetActive(false);
        ImageW.gameObject.SetActive(false);
    }
    
    void Transition(bool valid, int w, int h)
    {
        if (Active == true && Instance.Info == true)
        {
            TextH.text = h.ToString();
            TextW.text = w.ToString();

            ImageH.gameObject.SetActive(valid);
            ImageW.gameObject.SetActive(valid);
        }
    }
}
