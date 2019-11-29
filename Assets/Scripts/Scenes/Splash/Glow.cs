using System.Collections.Generic;
using UnityEngine;

public enum GlowMode
{
    Increase = 0,
    Decrease = 1
}

public class Glow : MonoBehaviour
{
    private GlowMode Mode = GlowMode.Decrease;

    [SerializeField]
    public UnityEngine.UI.Text Text;
    [SerializeField]
    public float A = 1f;
    [SerializeField]
    public float B = 0.25f;
    [SerializeField]
    public float Speed = 1.25f;

    void Update()
    {
        if (Text.color.a >= A)
        {
            Mode = GlowMode.Decrease;
        }

        if (Text.color.a <= B)
        {
            Mode = GlowMode.Increase;
        }

        switch (Mode)
        {
            case GlowMode.Increase:
            {
                Text.color = new Color(0f, 0f, 0f, (Text.color.a + (Speed * Time.deltaTime)));
            }
            break;

            case GlowMode.Decrease:
            {
                Text.color = new Color(0f, 0f, 0f, (Text.color.a - (Speed * Time.deltaTime)));
            }
            break;
        }
    }
}
