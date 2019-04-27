using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayCaster : MonoBehaviour
{
	private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.DrawRay(transform.position, (transform.position - agent.destination) * 100, Color.blue);
		transform.LookAt(agent.destination);
	}
}
