using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
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
}
