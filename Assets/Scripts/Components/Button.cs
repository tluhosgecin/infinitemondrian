using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void  Action(Button target);
    public static   event Action OnAction;

    private Color Color  = new Color(0f, 0f, 0f);
    private int   Status = 0;
    private bool  Change = false;

    [Header("Component")]
    public UnityEngine.UI.RawImage Image;
    public UnityEngine.UI.Text     Text;

    [Header("Button")]
    public bool Active = true;

    [Header("Tint")]
    public Color Normal;
    public Color Over;
    public Color Down;
    public Color Passive;

    [Header("Fade")]
    public float Current  = 0f;
    public float Duration = 0.1f;

    [Header("Highlight")]
    public string Message;
    public Color  Tint;

    void Update()
    {
        if (Active == true)
        {
            if (Image.color == Passive)
            {
                switch (Status)
                {
                    case 0:
                    {
                        Image.color = Normal;

                        break;
                    }

                    case 1:
                    {
                        Image.color = Over;
                        
                        break;
                    }

                    case 2:
                    {
                        Image.color = Down;
                        
                        break;
                    }
                }
            }

            if (Change == true)
            {
                Current += Time.deltaTime;

                if (Current > Duration)
                {
                    Current = Duration;
                }
                
                switch (Status)
                {
                    case 0:
                    {
                        Image.color = Ease(Current, Color, (Normal - Color), Duration);

                        if (Current >= Duration)
                        {
                            Change = false;
                        }

                        break;
                    }

                    case 1:
                    {
                        Image.color = Ease(Current, Color, (Over - Color), Duration);

                        if (Current >= Duration)
                        {
                            Change = false;
                        }

                        break;
                    }

                    case 2:
                    {
                        Image.color = Ease(Current, Color, (Down - Color), Duration);

                        if (Current >= Duration)
                        {
                            Change = false;
                        }

                        break;
                    }
                }
            }
        }
        else
        {
            if (Image.color != Passive)
            {
                Image.color = Passive;

                switch (Status)
                {
                    case 1:
                    {
                        if (Text != null)
                        {
                            Text.text = null;
                        }
                        
                        break;
                    }

                    case 2:
                    {
                        if (Text != null)
                        {
                            Text.text = null;
                        }

                        break;
                    }
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (Text != null)
        {
            Text.text = null;
        }

        Current = 0f;
        Color   = Image.color;
        Status  = 0;
        Change  = true;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (Active == true && Text != null)
        {
            Text.text  = Message;
            Text.color = Tint;
        }

        Current = 0f;
        Color   = Image.color;
        Status  = 1;
        Change  = true;
    }

    public void OnPointerDown(PointerEventData data)
    {
        Current = 0f;
        Color   = Image.color;
        Status  = 2;
        Change  = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (Status == 2 && OnAction != null)
        {
            OnAction(this);
        }
    }

    Color Ease(float time, Color begin, Color change, float duration)
    {
        return (change * time / duration + begin);
    }
}