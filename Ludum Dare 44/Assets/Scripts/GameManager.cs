using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	[Header("Enemy AI")]
	public GameObject[] Enemies;
	public int[] EnemyStartingCounts;
	public Transform[] SpawnPoints;

	[Header("Set Up")]
	public GameObject panel;
	public NecroHealth necroMancer;
	public TextMeshProUGUI instructionText;
	public TextMeshProUGUI controlsText;
	public GameObject gameOverMenu;

	[SerializeField]
	private List<GameObject> currentEnemies = new List<GameObject>();
	private int waveCount = 0;
	private LifeBuy lifeInfo;

    // Start is called before the first frame update
    void Start()
    {
		gameOverMenu.SetActive(false);
		necroMancer = FindObjectOfType<NecroHealth>();
		lifeInfo = necroMancer.GetComponent<LifeBuy>();
		StartCoroutine(GameLoop());
    }

	private void Update()
	{
		currentEnemies.RemoveAll(obj => obj == null);
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OpenBuildingMenu();
		}
	}

	private void SpawnWave(int wave)
	{
		// Spawn asset number of times equal to out put of function
		// Enemies[0] is the easiest while Enemies[n] is the hardest
		instructionText.text = "Wave: " + wave;
		controlsText.text = "press ESC to summon";
		necroMancer.healthPenalty = wave;
		for (int i = 0; i < Enemies.Length; i++)
		{
			SpawnThing(i, wave);
		}
	}

	private void SpawnThing(int x, int wave)
	{
		for (int i = 0; i < EnemyStartingCounts[x] + wave; i++)
		{
			int randint = Random.Range(0, SpawnPoints.Length);
			GameObject newEnemy = Instantiate(Enemies[x], SpawnPoints[randint].position, Quaternion.identity);
			currentEnemies.Add(newEnemy);
		}
	}

	private void EndGame()
	{
		print("you died");
		panel.SetActive(false);
		gameOverMenu.SetActive(true);
		instructionText.text = "";
		controlsText.text = "";
	}

	private void OpenBuildingMenu()
	{
		controlsText.text = "";
		panel.SetActive(true);
		lifeInfo.stillSelecting = true;
	}

	private IEnumerator GameLoop()
	{
		if (waveCount == 0)
		{
			yield return StartCoroutine(Picking());
		}
		SpawnWave(waveCount);
		waveCount++;
		yield return StartCoroutine(Fighting());

		if (necroMancer.GetHP() >= 0)
		{
			StartCoroutine(GameLoop());
		}
		else
		{
			EndGame();
		}

	}

	private IEnumerator Picking()
	{
		panel.SetActive(true);
		lifeInfo.stillSelecting = true;
		while (lifeInfo.stillSelecting)
		{
			yield return null;
		}
	}

	private IEnumerator Fighting()
	{
		while (currentEnemies.Count > 0)
		{
			if (necroMancer == null || necroMancer.GetHP() < 0)
			{
				EndGame();
			}
			yield return null;
		}
	}
}
