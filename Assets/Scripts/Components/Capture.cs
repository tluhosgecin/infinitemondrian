using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    [Header("Component")]
    public Fade Fade;

    [Header("Data")]
    public bool Active = true;

    void Update()
    {
        if (Active == true && Input.anyKey == true)
        {
            Fade.Status = true;
        }
    }
}
