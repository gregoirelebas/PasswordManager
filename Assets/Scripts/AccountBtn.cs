using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountBtn : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label = null;

	private MainCanvas mainCanvas = null;
	private AccountInfo info = null;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnClicked);
	}

	public void SetAccountInfo(MainCanvas mainCanvas, AccountInfo info)
	{
		this.mainCanvas = mainCanvas;
		this.info = info;

		label.text = info.Label;
	}

	public void OnClicked()
	{
		mainCanvas.DisplayInfoPanel(info);
	}
}
