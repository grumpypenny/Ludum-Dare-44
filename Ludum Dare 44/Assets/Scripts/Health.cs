﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
	protected float hp;

	public float startingHP = 100f;

	public bool isDead = false;
	public float lifeTime = 3.0f;

	private void Start()
	{
		hp = startingHP;
	}


	public void TakeDamage(float amount)
	{
		print(gameObject.name + " has taken " + amount + " damage");
		hp -= amount;

		if (hp <= 0 && !isDead){
			Die();
			isDead = true;
		}
	}

	private void Die()
	{
		// set the animation trigger
		Destroy(gameObject, lifeTime);
	}
}
