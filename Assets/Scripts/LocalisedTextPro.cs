﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalisedTextPro : MonoBehaviour
{
    [SerializeField] private string englishText = null;
    [SerializeField] private string frenchText = null;

    private TextMeshProUGUI textMesh = null;

	private void Awake()
	{
		textMesh = GetComponent<TextMeshProUGUI>();

		MainCanvas.Instance.OnLangSet += SetTextByLang;
	}

	private void OnEnable()
	{
		SetTextByLang();		
	}

	/// <summary>
	/// get MainCanvas current lang and adapt text.
	/// </summary>
	private void SetTextByLang()
	{
		switch (MainCanvas.Instance.CurrentLang)
		{
			case Lang.French:
				textMesh.text = frenchText;
				break;
		
			case Lang.English:
				textMesh.text = englishText;
				break;
			
			default:
				textMesh.text = englishText;

				Debug.LogWarning("Unknown lang : " + MainCanvas.Instance.CurrentLang.ToString() + ", setting english as default");
				break;
		}
	}
}
