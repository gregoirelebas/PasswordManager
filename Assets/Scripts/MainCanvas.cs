using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private InfoPanel infoPanel = null;

    public Action OnModification = null;

	private void Awake()
	{
        DataManager.Initialize();
    }

    /// <summary>
    /// Set active and set infos to display.
    /// </summary>
	public void DisplayInfoPanel(AccountInfo info)
	{
        infoPanel.gameObject.SetActive(true);
        infoPanel.SetInfos(info);
    }
}
