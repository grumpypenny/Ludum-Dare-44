using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(VilligerAnim))]
public class Enemy : MonoBehaviour
{
	[Header("Attack Variables")]
	public float damage = 2.0f;
	public float timeBetweenAttacks = 1.0f;

	private float timeOfNextAttack = 0;

	private Health health;
	private VilligerAnim anim;

	private void Start()
	{
		health = GetComponent<Health>();
		anim = GetComponent<VilligerAnim>();
		timeOfNextAttack = 0;
	}


	public void Attack(GameObject target)
	{
		if (target == this.gameObject || health.isDead)
		{
			return;
		}

		IHealth targetHP = target.GetComponent<IHealth>();
		if (targetHP != null && Time.time > timeOfNextAttack)
		{
			targetHP.TakeDamage(damage);
			timeOfNextAttack = Time.time + timeBetweenAttacks;
			anim.Attack();
		}
	}
}
