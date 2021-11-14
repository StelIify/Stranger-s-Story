using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onslaugth : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Text onslaugthText;

	public void SetMaxOnslaugth(int onslaugth)
	{
		slider.maxValue = onslaugth;
		slider.value = 0;
		onslaugthText.text = onslaugth.ToString();
		fill.color = gradient.Evaluate(1f);
	}

	public void SetOnslaugth(int onslaugth)
	{
		slider.value = onslaugth;
		onslaugthText.text = onslaugth.ToString();
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
