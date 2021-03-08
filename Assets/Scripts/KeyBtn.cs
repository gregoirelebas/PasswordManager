using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBtn : MonoBehaviour
{
	public int Value { get; private set; } = 0;

	[SerializeField] private TextMeshProUGUI valueText = null;

	public void SetValue(int newValue)
	{
		Value = newValue;

		valueText.text = Value.ToString();
	}	
}
