using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
	protected float hp;

	public float startingHP = 100f;
	public bool spawnBlood = false;
	public bool isDead = false;
	public float lifeTime = 3.0f;
	public GameObject blood;
	private VilligerAnim anim;

	private void Start()
	{
		hp = startingHP;
		anim = GetComponent<VilligerAnim>();
	}


	public void TakeDamage(float amount)
	{
		hp -= amount;

		if (hp <= 0 && !isDead){
			Die();
			isDead = true;
		}
	}

	private void Die()
	{
		// set the animation trigger
		if (anim != null)
		{
			anim.Die();
		}

		if (spawnBlood)
		{
			Instantiate(blood, transform.position, new Quaternion(0,0,0,0));
		}

		Destroy(gameObject, lifeTime);
		if (transform.parent != null)
		{
			Destroy(transform.parent.gameObject, lifeTime);
		}
	}
}
