using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private ListPanel listPanel = null;
    [SerializeField] private InfoPanel infoPanel = null;
    [SerializeField] private EditionPanel editionPanel = null;

    public Action OnModification = null;

	private void Awake()
	{
        DataManager.Initialize();
    }

	public void DisplayInfoPanel(AccountInfo info)
	{
        infoPanel.gameObject.SetActive(true);
        infoPanel.SetInfos(info);
    }
}
