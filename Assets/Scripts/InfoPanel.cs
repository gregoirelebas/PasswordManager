using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
	[Header("Info fields")]
	[SerializeField] private TextMeshProUGUI labelField = null;
	[SerializeField] private TextMeshProUGUI idField = null;
	[SerializeField] private TextMeshProUGUI passwordField = null;

	[Header("Edition")]
	[SerializeField] private EditionPanel editionPanel = null;
	[SerializeField] private Button modifyBtn = null;
	[SerializeField] private Button deleteBtn = null;

	private MainCanvas mainCanvas = null;
	private AccountInfo info = null;

	private void Awake()
	{
		mainCanvas = GetComponentInParent<MainCanvas>();

		modifyBtn.onClick.AddListener(Modify);
		deleteBtn.onClick.AddListener(Delete);
	}

	/// <summary>
	/// Update text based on infos.
	/// </summary>
	public void SetInfos(AccountInfo info)
	{
		this.info = info;

		labelField.text = info.Label;
		idField.text = info.Id;
		passwordField.text = info.Password;
	}

	/// <summary>
	/// Set active the edition panel and desactivate self.
	/// </summary>
	public void Modify()
	{
		editionPanel.gameObject.SetActive(true);
		editionPanel.SetInfo(info);

		gameObject.SetActive(false);
	}

	/// <summary>
	/// Delete the AccountInfo and desactivate self.
	/// </summary>
	public void Delete()
	{
		DataManager.DeleteInfo(info);

		mainCanvas.OnModification?.Invoke();

		gameObject.SetActive(false);
	}
}
