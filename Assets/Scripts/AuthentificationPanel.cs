using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthentificationPanel : MonoBehaviour
{
	public Action OnUnlock = null;

	[SerializeField] private KeyPanel keyPanel = null;

	private void Awake()
	{
		keyPanel.OnKeyTry += UnlockData;
	}

	private void UnlockData(string inputKey)
	{
		Debug.Log("Matching user key with registered key...");
		Debug.Log(inputKey);

		if (inputKey.Equals("1111"))
		{
			DataManager.IsUnlocked = true;

			OnUnlock?.Invoke();

			gameObject.SetActive(false);
		}
		else
		{
			keyPanel.ResetKeySystem();
		}
	}
}
