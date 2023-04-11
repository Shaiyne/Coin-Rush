using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class edgeplanedeneme : MonoBehaviour
{
    NavMeshSurface navMesh;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshSurface>();

    }
    private void Start()
    {
        navMesh.BuildNavMesh();
    }
}
