using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
	[SerializeField] private ConfirmationPopup confirmationPopup = null;

	private MainCanvas mainCanvas = null;

	private void Awake()
	{
		mainCanvas = GetComponentInParent<MainCanvas>();
	}

	public void SetEnglish()
	{
		mainCanvas.SetLang(Lang.English);
	}

	public void SetFrench()
	{
		mainCanvas.SetLang(Lang.French);
	}

	public void EraseAllData()
	{
		confirmationPopup.OnValidation += () =>
		{
			DataManager.DeleteAllInfos();

			mainCanvas.OnModification();

			gameObject.SetActive(false);
		};

		confirmationPopup.gameObject.SetActive(true);
	}
}
