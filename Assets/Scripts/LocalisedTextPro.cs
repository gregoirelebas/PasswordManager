using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalisedTextPro : MonoBehaviour
{
    [SerializeField] private string frenchText = null;
    [SerializeField] private string englishText = null;

	private MainCanvas mainCanvas = null;
    private TextMeshProUGUI textMesh = null;

	private void Awake()
	{
		textMesh = GetComponent<TextMeshProUGUI>();
		mainCanvas = GetComponentInParent<MainCanvas>();

		SetTextByLang();
		mainCanvas.OnLangSet += SetTextByLang;
	}

	/// <summary>
	/// get MainCanvas current lang and adapt text.
	/// </summary>
	private void SetTextByLang()
	{
		switch (mainCanvas.CurrentLang)
		{
			case Lang.French:
				textMesh.text = frenchText;
				break;
		
			case Lang.English:
				textMesh.text = englishText;
				break;
			
			default:
				textMesh.text = englishText;

				Debug.LogWarning("Unknown lang : " + mainCanvas.CurrentLang.ToString() + ", setting english as default");
				break;
		}
	}
}
