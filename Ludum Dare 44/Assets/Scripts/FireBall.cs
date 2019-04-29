using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
	[HideInInspector]
	public Vector3 direction;

	public LayerMask hitMask;
	public float speed;

	private float damage;

	public void SetDirection(Vector3 dir)
	{
		direction = dir;
	}

	public void SetDamage(float _damage)
	{
		damage = _damage;
	}

    // Update is called once per frame
    void Update()
    {
		transform.Translate(direction.normalized * speed * Time.deltaTime);
		Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f, hitMask);
		if (colliders.Length > 0)
		{
			foreach (Collider collider in colliders)
			{
				IHealth targetHP = collider.GetComponent<IHealth>();

				if (targetHP == null)
				{
					// search in children too
					targetHP = collider.GetComponentInChildren<IHealth>();
				}

				if (targetHP != null)
				{
					targetHP.TakeDamage(damage);
				}

				Destroy(gameObject);
			}
		}
	}
}
