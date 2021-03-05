using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Lang
{
	French,
	English
}

public class MainCanvas : MonoBehaviour
{
	[SerializeField] private InfoPanel infoPanel = null;

	public Action OnModification = null;
	public Action OnLangSet = null;

	public Lang CurrentLang { get; private set; } = Lang.English;

	private void Awake()
	{
		DataManager.Initialize();

		OnModification += DataManager.SaveData;
	}

	/// <summary>
	/// Set active and set infos to display.
	/// </summary>
	public void DisplayInfoPanel(AccountInfo info)
	{
		infoPanel.gameObject.SetActive(true);
		infoPanel.SetInfos(info);
	}

	/// <summary>
	/// Set a new lang to use and trigger Action OnLangSet.
	/// </summary>
	public void SetLang(Lang newLang)
	{
		CurrentLang = newLang;

		OnLangSet?.Invoke();
	}
}
