using UnityEngine;

public class Glow : MonoBehaviour
{
    [Header("Component")]
    public UnityEngine.UI.Text Text;

    [Header("Data")]
    public float Speed = 1.25f;
    public int   Drift = 1;
    public float Start = 1f;
    public float Close = 0.2f;

    void Update()
    {
        if (Text.color.a >= Start)
        {
            Drift = 0;
        }

        if (Text.color.a <= Close)
        {
            Drift = 1;
        }

        switch (Drift)
        {
            case 1:
            {
                Text.color = new Color(0f, 0f, 0f, (Text.color.a + (Speed * Time.deltaTime)));
            }
            break;

            case 0:
            {
                Text.color = new Color(0f, 0f, 0f, (Text.color.a - (Speed * Time.deltaTime)));
            }
            break;
        }
    }
}
