using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBtn : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI valueText = null;

	private AuthentificationPanel panel = null;
	private Button button = null;
	private int keyValue = 0;

	private void Awake()
	{
		panel = GetComponentInParent<AuthentificationPanel>();
		button = GetComponent<Button>();

		button.onClick.AddListener(() => panel.OnKeyPressed(keyValue));
	}

	public void SetValue(int newValue)
	{
		keyValue = newValue;

		valueText.text = keyValue.ToString();

		
	}
}
