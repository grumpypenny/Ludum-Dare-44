using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUIText : MonoBehaviour
{
	private Slider slider;
	private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
		slider = GetComponentInParent<Slider>();
		text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
		text.text = "HP: " + slider.value;
    }
}
