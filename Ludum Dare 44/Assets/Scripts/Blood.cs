using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
	public GameObject necro;
	public int hpBoost = 25;


    // Start is called before the first frame update
    void Start()
    {
		necro = FindObjectOfType<NecroHealth>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		if ((transform.position - necro.transform.position).sqrMagnitude > 1)
		{
			transform.Translate((necro.transform.position - transform.position).normalized * Time.deltaTime);
		}
		else
		{
			necro.GetComponent<NecroHealth>().IncreaseHealth(hpBoost);
			Destroy(gameObject);
		}
    }
}
