using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] GameObject startingPlane;
    [SerializeField] PlaneSO _planesSO;
    [SerializeField] List<NavMeshSurface> _navMeshSurfaces = new List<NavMeshSurface>();
    [SerializeField] GameObject levelFinishStagePrefab;
    bool createdComplate;

    private void Awake()
    {
        this.Wait(0.2f, () => // Loading Time
        {
            CreatePlanes();
        });

        
    }
    private void Start()
    {
        this.Wait(0.5f, () =>
        {
            BuildNavMeshesPlane();
        });

    }

    private void CreatePlanes()
    {
        for (int i = 0; i < SaveGameManager.CurrentSaveData.LevelData.PlaneCount; i++)
        {
            GameObject planeIns = Instantiate(_planesSO.Planes[Random.Range(0, _planesSO.Planes.Length)], this.gameObject.transform);
            _navMeshSurfaces.Add(planeIns.GetComponent<NavMeshSurface>());
            planeIns.transform.position = new Vector3(planeIns.transform.position.x, 0, SaveGameManager.GetPlanePosZLenght() * (i + 1));
            if (i + 1 == SaveGameManager.CurrentSaveData.LevelData.PlaneCount)
            {
                GameObject lfsIns = Instantiate(levelFinishStagePrefab);
                lfsIns.transform.position = new Vector3(0, 0, (i + 2) * SaveGameManager.GetPlanePosZLenght());
                _navMeshSurfaces.Add(lfsIns.GetComponent<NavMeshSurface>());
                _navMeshSurfaces.Add(startingPlane.GetComponent<NavMeshSurface>());
                createdComplate = true;
            }
        }
    }
    private void BuildNavMeshesPlane()
    {
        if (createdComplate)
        {
            for (int i = 0; i < _navMeshSurfaces.Count; i++)
            {
                _navMeshSurfaces[i].BuildNavMesh();
            }
        }
    }
}
