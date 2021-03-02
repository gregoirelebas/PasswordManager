using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI labelField = null;
	[SerializeField] private TextMeshProUGUI idField = null;
	[SerializeField] private TextMeshProUGUI passwordField = null;

    public void SetInfos(AccountInfo info)
	{
		labelField.text = info.Label;
		idField.text = info.Id;
		passwordField.text = info.Password;
	}
}
