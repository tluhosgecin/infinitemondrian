using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    private Vector3 Root = new Vector3(0f, 0f, -1f);

    [Header("Movement")]
    public float Speed = 2f;

    [Header("Data")]
    public List<Pipe> PipeList;

    void Update()
    {
        if (transform.position.z <= -1f)
        {
            /*
            *   Reset The Tunnel Position
            */
            Root.x = 0f;
            Root.y = 0f;
            Root.z = 0f;
            
            transform.position = Root;

            /*
            *   Order Each Pipe And Assign Pipe Positions
            */
            var Object = PipeList[0];
            
            foreach (var Pipe in PipeList)
            {
                if (Pipe == Object)
                {
                    Root.x = 0f;
                    Root.y = 0f;
                    Root.z = PipeList.Count - 1;

                    Pipe.transform.position = Root;
                }
                else
                {
                    Root.x = 0f;
                    Root.y = 0f;
                    Root.z = -1f;

                    Pipe.transform.position += Root;
                }
            }
            
            PipeList.Add(Object);
            PipeList.RemoveAt(0);
        }

        /*
        *   Calculate Tunnel Movement
        */
        Root.x = 0f;
        Root.y = 0f;
        Root.z = -1f;

        transform.position += Root * Time.deltaTime * Speed;
    }
}
