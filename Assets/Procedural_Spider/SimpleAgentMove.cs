using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgentMove : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;
    private NavMeshPath path;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.updatePosition = false;
        path = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(target.position);
            if (NavMesh.CalculatePath(agent.transform.position, target.position, NavMesh.AllAreas, path))
            {
                foreach(Vector3 corner in path.corners)
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    go.transform.position = corner;
                }
            }
        }
        
        
        
        
    }
}
