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
	private SpriteRenderer sprite;

	private void Start()
	{
		hp = startingHP;
		anim = GetComponent<VilligerAnim>();
		sprite = GetComponent<SpriteRenderer>();
	}

	public float GetHP()
	{
		return hp;
	}

	public void TakeDamage(float amount)
	{
		hp -= amount;
		sprite.color = Color.red;
		StartCoroutine(Flash());

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

		if (transform.parent != null)
		{
			Destroy(transform.parent.gameObject, lifeTime);
		}
	}

	private IEnumerator Flash()
	{
		yield return new WaitForSeconds(0.1f);
		sprite.color = Color.white;
		StopCoroutine(Flash());
	}
}
