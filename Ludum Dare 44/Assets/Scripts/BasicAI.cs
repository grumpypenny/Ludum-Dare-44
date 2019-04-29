using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Health))]
public class BasicAI : MonoBehaviour
{
	[Header ("Debug")]
	public Color colour = Color.red;

	[Space]

	[Header("Movement")]
	public NavMeshAgent agent;
	public Camera cam;
	public float speed;
	public float distance = 1.0f;

	[Space]

	[Header("Navigation")]
	public List<Transform> targets = new List<Transform>();
	public float radius = 15.0f;
	public LayerMask TargetMask;

	private GameObject destination;
	private Enemy self;
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
		UpdateTargetList();

		self = GetComponent<Enemy>();
	}

    // Update is called once per frame
    void Update()
    {
		//transform.LookAt(agent.destination);

		// Set the destination
		if (destination == null || destination == this.gameObject)
		{
			UpdateDestination();
		}
		Move(destination.transform.position);


		// reset transform to normal
		//transform.eulerAngles = Vector3.Scale(transform.eulerAngles, new Vector3(0, 0, 1));
		transform.rotation = Quaternion.FromToRotation(Vector3.up, -(transform.position - destination.transform.position));
		Debug.DrawLine(transform.position, destination.transform.position, colour);
	}

	private void Move(Vector2 t)
	{
		// move to random target
		UpdateTargetList();

		if (((Vector2)transform.position - t).magnitude > distance)
		{
			agent.SetDestination(t);
		}
		else
		{
			self.Attack(destination);
		}
	}

	private void UpdateDestination()
	{
		UpdateTargetList();
		if (targets.Count > 0)
		{
			int r = Random.Range(0, targets.Count);
			destination = targets[r].gameObject;
		} else
		{
			destination = this.gameObject;
		}
	}

	private void UpdateTargetList()
	{
		targets.Clear();

		Collider[] colliders = Physics.OverlapSphere(transform.position, radius, TargetMask);

		for (int i = 0; i < colliders.Length; i++)
		{
			targets.Add(colliders[i].transform);
		}
	}

	#region MovementTest

	private void MoveToClick()
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
	#endregion


}
