using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Text healthText;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
		healthText.text =  slider.value.ToString();
		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		slider.value = health;
		healthText.text = health.ToString();
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
