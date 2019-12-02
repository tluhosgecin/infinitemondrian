using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public Fade Fade;

    [Header("Timer")]
    public float Current  = 0f;
    public float Duration = 3f;

    [Header("Data")]
    public bool Active = true;
    
    void Update()
    {
        if (Active == true)
        {
            Current += Time.deltaTime;

            if (Current >= Duration)
            {
                Active  = false;
                Current = 0f;

                Fade.Status = true;
            }
        }
    }
}
