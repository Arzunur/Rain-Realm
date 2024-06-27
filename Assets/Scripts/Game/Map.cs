using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Ins;

    public Vector2 MapLimit;

    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(MapLimit.x * 2, 1, MapLimit.y * 2));
    }

}
