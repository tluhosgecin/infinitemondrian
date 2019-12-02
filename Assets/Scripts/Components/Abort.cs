using UnityEngine;

public class Abort : MonoBehaviour
{
    [Header("Component")]
    public Fade Fade;

    [Header("Input")]
    public KeyCode Key = KeyCode.Backspace;

    [Header("Data")]
    public bool Active = true;

    void Update()
    {
        if(Active == true && Input.GetKeyDown(Key) == true)
        {
            Fade.Status = true;
        }
    }
}
