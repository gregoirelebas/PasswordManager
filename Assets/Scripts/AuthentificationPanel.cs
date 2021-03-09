using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthentificationPanel : MonoBehaviour
{
	public System.Action OnUnlock = null;

	[SerializeField] private KeyPanel keyPanel = null;

	private string userCode = "";

	private void Awake()
	{		
		keyPanel.OnCodeAccess += UnlockData;
	}

	private void OnEnable()
	{
		userCode = PlayerPrefs.GetString("UserCode", "");
	}

	private void UnlockData(string inputKey)
	{
		Debug.Log("Matching user key with registered key...");
		Debug.Log(inputKey);

		if (inputKey.Equals(userCode))
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
