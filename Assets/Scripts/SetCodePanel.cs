using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCodePanel : MonoBehaviour
{
	[SerializeField] private LocalisedTextPro oldCodeText = null;
	[SerializeField] private LocalisedTextPro newCodeText = null;

	[SerializeField] private KeyPanel keyPanel = null;

	private string userCode = "";

	private bool oldCodeUnlocked = false;

	private void Awake()
	{
		userCode = PlayerPrefs.GetString("UserCode", "");
		if (userCode.Equals(""))
		{
			oldCodeUnlocked = true;
		}
	}

	private void OnEnable()
	{
		if (oldCodeUnlocked)
		{
			keyPanel.OnCodeAccess += SetNewCode;

			oldCodeText.gameObject.SetActive(false);
			newCodeText.gameObject.SetActive(true);
		}
		else
		{
			keyPanel.OnCodeAccess += UnlockOldCode;

			oldCodeText.gameObject.SetActive(true);
			newCodeText.gameObject.SetActive(false);
		}
	}

	private void OnDisable()
	{
		if (oldCodeUnlocked)
		{
			keyPanel.OnCodeAccess -= SetNewCode;
		}
		else
		{
			keyPanel.OnCodeAccess -= UnlockOldCode;
		}
	}

	private void UnlockOldCode(string oldCode)
	{
		if (oldCode.Equals(userCode))
		{
			oldCodeUnlocked = true;

			oldCodeText.gameObject.SetActive(false);
			newCodeText.gameObject.SetActive(true);

			keyPanel.ResetKeySystem();

			keyPanel.OnCodeAccess -= UnlockOldCode;
			keyPanel.OnCodeAccess += SetNewCode;
		}
		else
		{
			keyPanel.ResetKeySystem();
		}
	}

	private void SetNewCode(string newCode)
	{
		userCode = newCode;

		keyPanel.OnCodeAccess -= SetNewCode;

		PlayerPrefs.SetString("UserCode", userCode);
		PlayerPrefs.Save();

		Close();
	}

	public void Close()
	{
		oldCodeUnlocked = false;

		gameObject.SetActive(false);
	}
}
