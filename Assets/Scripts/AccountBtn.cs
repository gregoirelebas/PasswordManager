using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountBtn : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label = null;

	private AccountInfo info = null;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnClicked);
	}

	/// <summary>
	/// Update text based on info.
	/// </summary>
	public void SetAccountInfo(AccountInfo info)
	{
		this.info = info;

		label.text = info.Label;
	}

	/// <summary>
	/// Ask MainCanvas to diplay the InfoPanel.
	/// </summary>
	public void OnClicked()
	{
		MainCanvas.Instance.DisplayInfoPanel(info);
	}
}
