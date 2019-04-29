using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Health))]
public class MageAI : MonoBehaviour
{
	[Header("attack variables")]
	public List<Transform> targets = new List<Transform>();
	public float radius = 80f;
	public LayerMask TargetMask;
	public float damage = 100f;

	public GameObject fireBall;

	private Animator anim;
	private Health health;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		UpdateTargetList();

		if (targets.Count > 0)
		{
			anim.SetBool("attack", true);
		}
		else
		{
			anim.SetBool("attack", false);
		}

		Spin();
	}

	private void Spin()
	{
		transform.Rotate(transform.forward);
	}

	public void SpawnFireBall()
	{
		if (fireBall != null)
		{
			GameObject ball = Instantiate(fireBall, transform.position, Quaternion.identity);
			FireBall fir = ball.GetComponent<FireBall>();
			Transform t = FindClosestTarget();
			fir.SetDamage(damage);
			if (t != null)
			{
				// note t may be destroyed 
				fir.SetDirection(-(transform.position - t.position));
			}
		}
	}
	
	private Transform FindClosestTarget()
	{
		// return transform of closest target
		float dst = Mathf.Infinity;
		Transform temp = null;
		foreach (Transform t in targets)
		{
			float new_dst = Vector3.Distance(t.position, transform.position);
			if (new_dst < dst)
			{
				dst = new_dst;
				temp = t;
			}
		}

		return temp;
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

}
