using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
	[SerializeField] private InfoPanel infoPanel = null;

	public Action OnModification = null;

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

#if UNITY_EDITOR
	public void OnGUI()
	{
		if (GUI.Button(new Rect(0.0f, 0.0f, 100.0f, 20.0f), "Clear Prefs"))
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
		}
	}
#endif
}
