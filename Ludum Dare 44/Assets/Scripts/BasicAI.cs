using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
	public NavMeshAgent agent;

	public Camera cam;

	public float difference = 2.0f;
	public float speed;

	/*
	 * This script goes on the child of an agent
	 */


	void Awake()
    {
		cam = Camera.main;
		if (speed == 0.0)
		{
			speed = agent.speed;
		}
    }

    // Update is called once per frame
    void Update()
    {
		// reset transform to normal
		transform.eulerAngles = new Vector3(0, 0, 0);
		Move();
    }

	private void Move()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination(hit.point);
			}
		}
	}
}
