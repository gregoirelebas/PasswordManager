using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPopup : MonoBehaviour
{
	public Action OnValidation = null;

	private void OnDisable()
	{
		OnValidation = null;
	}

	public void Yes()
	{
		OnValidation?.Invoke();

		OnValidation = null;

		gameObject.SetActive(false);
	}
}
