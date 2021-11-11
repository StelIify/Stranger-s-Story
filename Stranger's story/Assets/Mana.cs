using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Text manaText;

	public void SetMaxMana(int mana)
	{
		slider.maxValue = mana;
		slider.value = mana;
		manaText.text = mana.ToString();
		fill.color = gradient.Evaluate(1f);
	}

	public void SetMana(int mana)
	{
		slider.value = mana;
		manaText.text = mana.ToString();
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
