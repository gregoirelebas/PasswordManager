using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class KeyPanel : MonoBehaviour
{
	private const int KEY_LENGTH = 4;

	public Action OnUnlock = null;

	[SerializeField] private TextMeshProUGUI keyFieldText = null;
	[SerializeField] private Transform keyContainer = null;

	private KeyBtn[] keys = null;
	private List<int> keyValues = new List<int>();

	private string userKey = "";
	private int inputCount = 0;

	private void Awake()
	{
		keys = keyContainer.GetComponentsInChildren<KeyBtn>();

		for (int i = 0; i < keys.Length; i++)
		{
			keyValues.Add(i + 1);
		}
	}

	private void OnEnable()
	{
		ResetKeySystem();		
	}

	private void ResetKeySystem()
	{
		keyFieldText.text = "- - - -";
		inputCount = 0;
		userKey = "";

		System.Random rnd = new System.Random();
		keyValues = keyValues.OrderBy(x => rnd.Next()).ToList();

		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].SetValue(keyValues[i]);
		}
	}

	public void OnKeyPressed(int keyValue)
	{
		inputCount++;
		if (inputCount <= KEY_LENGTH)
		{
			userKey += keyValue.ToString();

			char[] keyChar = keyFieldText.text.ToCharArray();
			keyChar[(inputCount - 1) * 2] = '*';
			keyFieldText.text = new string(keyChar);

			if (inputCount == KEY_LENGTH)
			{
				Debug.Log("Matching user key with registered key...");
				Debug.Log(userKey);

				if (userKey.Equals("1111"))
				{
					DataManager.IsUnlocked = true;

					OnUnlock?.Invoke();

					gameObject.SetActive(false);
				}
				else
				{
					ResetKeySystem();
				}
			}
		}
	}
}
