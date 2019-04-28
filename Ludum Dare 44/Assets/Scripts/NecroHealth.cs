using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NecroHealth : Health
{
	public Slider hpSlider;

	public void IncreaseHealth(int amount)
	{
		if (hp >= 0 && !isDead)
		{
			hp += amount;
		}
	}

	public void DefenceCost(int amount)
	{
		if (hp >= 0 && !isDead)
		{
			hp -= amount;
		}
	}

	private void Update()
	{
		hpSlider.value = hp;
	}
}
