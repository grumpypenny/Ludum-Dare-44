using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
	public GameObject blood;

	public float timeBetweenOfferings = 10f;

	private float timeOfNextOffering = 21;

    // Update is called once per frame
    void Update()
    {
		if (Time.time > timeOfNextOffering)
		{
			Instantiate(blood, transform.position, Quaternion.identity);
			timeOfNextOffering = Time.time + timeBetweenOfferings;
		}
    }
}
