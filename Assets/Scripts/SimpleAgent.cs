using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgent : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    Vector3[] pathPoints;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Here");

            if (Physics.Raycast(ray, out hit))
            {
                NavMeshPath path = new NavMeshPath();
                if (NavMesh.CalculatePath(this.transform.position, hit.point, NavMesh.AllAreas, path))
                {
                    pathPoints = path.corners; 
                }
                agent.SetDestination(hit.point);
            }
        }
        if (pathPoints != null && pathPoints.Length > 1)
        {
            for (int i = 1; i < pathPoints.Length; i++)
            {
                Debug.DrawLine(pathPoints[i], pathPoints[i - 1]);
            }
        
        }
    }
}
