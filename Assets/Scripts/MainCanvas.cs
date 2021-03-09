using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Lang
{
	English,
	French
}

public class MainCanvas : MonoBehaviour
{
	[SerializeField] private InfoPanel infoPanel = null;
	[SerializeField] private AuthentificationPanel keyPanel = null;
	[SerializeField] private Lang debugLang = Lang.French;

	public Action OnModification = null;
	public Action OnLangSet = null;

	public Lang CurrentLang { get; private set; } = Lang.English;

	private void Awake()
	{
		DataManager.Initialize();

#if UNITY_EDITOR
		CurrentLang = debugLang;
#endif

		OnModification += DataManager.SaveData;
	}

	private void OnApplicationFocus(bool focus)
	{
		if (DataManager.IsUnlocked && focus == false)
		{
			DataManager.IsUnlocked = false;
		}
	}

	/// <summary>
	/// Set active and set infos to display.
	/// </summary>
	public void DisplayInfoPanel(AccountInfo info)
	{
		if (DataManager.IsUnlocked)
		{
			infoPanel.gameObject.SetActive(true);
			infoPanel.SetInfos(info);
		}
		else
		{
			keyPanel.gameObject.SetActive(true);
			keyPanel.OnUnlock += () =>
			{
				DisplayInfoPanel(info);
			};
		}
	}

	/// <summary>
	/// Set a new lang to use and trigger Action OnLangSet.
	/// </summary>
	public void SetLang(Lang newLang)
	{
		CurrentLang = newLang;

#if DEBUG
		Debug.Log("Set lang : " + newLang.ToString());
#endif

		OnLangSet?.Invoke();
	}
}
