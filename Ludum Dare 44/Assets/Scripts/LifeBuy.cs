using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeBuy : MonoBehaviour
{
	[Header("Player")]
	public NecroHealth health;

	[Space]

	[Header("UI")]
	public GameObject panel;
	public TextMeshProUGUI instructionText;

	[Space]

	[Header("Objects")]
	public GameObject SkeletonWarrior;
	public float warriorCost = 200f;
	public GameObject SkeletonMage;
	public float mageCost = 350f;

	[HideInInspector]
	public bool stillSelecting = false;

    // Start is called before the first frame update
    void Start()
    {
		health = FindObjectOfType<NecroHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void BuySkeletonWarrior()
	{
		if (health.GetHP() > warriorCost + 1)
		{
			// Instanciate Knight
			SpawnOnClick(SkeletonWarrior);
			health.TakeDamage(warriorCost);
		}
	}

	public void BuySkeletonMage()
	{
		if (health.GetHP() > mageCost + 1)
		{
			// Instanciate Mage
			SpawnOnClick(SkeletonMage);
			health.TakeDamage(mageCost);
		}
	}

	private void SpawnOnClick(GameObject @object)
	{
		ClosePanel();
		instructionText.text = "Click to Spawn";

		StartCoroutine(WaitForClick(@object));
	}


	public void ClosePanel()
	{
		panel.SetActive(false);
	}

	public void OpenPanel()
	{
		stillSelecting = true;
		panel.SetActive(true);
	}

	public void ConfirmEndSelection()
	{
		stillSelecting = false;
	}

	public IEnumerator WaitForClick(GameObject @object)
	{
		yield return new WaitForSeconds(0.1f);
		while (true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;


				if (Physics.Raycast(ray, out hit))
				{
					Instantiate(@object, hit.point, Quaternion.identity);

					instructionText.text = "";
					OpenPanel();
					yield break;
				}
			}

			yield return null;
		}
	}
}
