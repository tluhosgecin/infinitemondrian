using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void  Point(bool valid, int w, int h);
    public static   event Point OnPoint;

    private RaycastHit Info;

    [Header("Component")]
    public Camera              Camera;
    public CharacterController Controller;
    
    [Header("Movement")]
    public float Speed = 2f;

    [Header("Information")]
    public bool Enabled = true;

    void Update()
    {
        if (Instance.Ready == true)
        {
            if (Enabled == true)
            {
                Vector3 Root = Camera.transform.position;
                Vector3 Base = Camera.transform.TransformDirection(Vector3.forward);
                
                RaycastHit Temp;

                if (Physics.Raycast(Root, Base, out Temp) == true && Temp.transform != Info.transform)
                {
                    Info = Temp;

                    if (Info.transform.tag == "Piece")
                    {    
                        Piece Piece = Info.transform.GetComponent<Piece>();
                        
                        if (OnPoint != null)
                        {
                            OnPoint(true, Piece.Latitude, Piece.Altitude);
                        }
                    }
                    else
                    {
                        if (OnPoint != null)
                        {
                            OnPoint(false, 0, 0);
                        }
                    }
                }
            }

            Ray Line = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Line) == true)
            {
                Controller.Move(new Vector3(Line.direction.x, Line.direction.y, 0f) * Speed * Time.deltaTime);
            }
        }
    }
}