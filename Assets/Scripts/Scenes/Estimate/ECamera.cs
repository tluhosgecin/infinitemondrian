using UnityEngine;

public enum EMouseType
{
    Left   = 0,
    Right  = 1,
    Middle = 2
}

public class ECamera : MonoBehaviour
{
    [Header("Component")]
    public Camera              Target;
    public CharacterController Control;

    [Header("Control")]
    public EMouseType Mouse = EMouseType.Left;

    [Header("Movement")]
    public float Speed = 1.5f;
    
    void Update()
    {
        if (ETunnel.Active == true && Input.GetMouseButton(((int) Mouse)))
        {
            Ray Line = Target.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Line))
            {
                float X = Line.direction.x * Speed;
                float Y = Line.direction.y * Speed;
                
                Control.Move(new Vector3(X, Y, 0f) * Time.deltaTime);
            }
        }
    }
}