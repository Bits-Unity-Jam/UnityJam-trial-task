using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_Rotation : MonoBehaviour
{
    public AIPath aiPath;
    
    void Update()
    {
        if (aiPath.desiredVelocity.x>=0.01f)
        {
            transform.localScale= new Vector3(3.673539f, 4.19854f, 1);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) 
        {
            transform.localScale = new Vector3(-3.673539f, 4.19854f, 1);
        }
    }
}
