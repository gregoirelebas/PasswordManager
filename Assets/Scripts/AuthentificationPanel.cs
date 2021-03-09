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

	/// <summary>
	/// Try to match inputKey with userKey. If success, unlock data access.
	/// </summary>
	private void UnlockData(string inputKey)
	{
#if DEBUG
		Debug.Log("Matching user key with registered key...");
		Debug.Log(inputKey);
#endif

		if (inputKey.Equals(userCode))
		{
			DataManager.IsUnlocked = true;

			OnUnlock?.Invoke();

			gameObject.SetActive(false);
		}
		else
		{
			keyPanel.ResetKeySystem();

			MainCanvas.Instance.SendNotification(NotificationType.WrongPassword);
		}
	}
}
