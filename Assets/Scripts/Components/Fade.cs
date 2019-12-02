using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [Header("Component")]
    public UnityEngine.UI.RawImage Target;

    [Header("Scene")]
    public int Index = 0;

    [Header("Timer")]
    public float Current  = 0f;
    public float Duration = 0.5f;

    [Header("Data")]
    public Color Black;
    public Color Transparent;
    public bool  Active = true;
    public bool  Status = false;

    
    void Update()
    {
        if (Active == true)
        {
            Target.color = Ease(Current += Time.deltaTime, Black, (Transparent - Black), Duration);

            if (Current >= Duration)
            {
                Target.color = Transparent;

                Active  = false;
                Current = Duration;
            }
        }
        else
        {
            if (Status == true)
            {
                Target.color = Ease(Current -= Time.deltaTime, Black, (Transparent - Black), Duration);

                if (Current <= 0)
                {
                    SceneManager.LoadScene(Index, LoadSceneMode.Single);
                }
            }
        }
    }
    
    Color Ease(float time, Color begin, Color change, float duration)
    {
		return ((change * -1) * Mathf.Cos(time / duration * (Mathf.PI / 2)) + change + begin);
	}
}