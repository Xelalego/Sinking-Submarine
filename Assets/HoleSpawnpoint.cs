using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HoleSpawnpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Game.Manager.HoleSpawnpoints.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.DrawRay(transform.position, transform.forward * 0.5f);
        Gizmos.DrawSphere(transform.position + transform.forward * 0.5f, 0.02f);
    }

    void OnDestroy()
    {
        if (Game.Manager) Game.Manager.HoleSpawnpoints.Remove(transform);
    }
}
