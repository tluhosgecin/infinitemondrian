using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Component")]
    public UnityEngine.UI.Text Text;

    [Header("Data")]
    public int Value = 0;

    void Start()
    {
        Text.text = (Value = Instance.Score).ToString();
    }

    void Update()
    {
        if (Value != Instance.Score)
        {
            Text.text = (Value = Instance.Score).ToString();
        }
    }
}
