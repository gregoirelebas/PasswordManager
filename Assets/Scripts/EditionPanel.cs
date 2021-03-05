using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditionPanel : MonoBehaviour
{
	[Header("Info fields")]
	[SerializeField] TMP_InputField labelField = null;
	[SerializeField] TMP_InputField idField = null;
	[SerializeField] TMP_InputField passwordField = null;

	[Header("")]
	[SerializeField] private Button validBtn = null;

	private MainCanvas mainCanvas = null;
	private AccountInfo info = null;

	private void Awake()
	{
		mainCanvas = GetComponentInParent<MainCanvas>();
	}

	private void OnEnable()
	{
		labelField.text = "";
		idField.text = "";
		passwordField.text = "";

		SetInfo(null);
	}

	/// <summary>
	/// Return true if all input field texts are not empty strings.
	/// </summary>
	/// <returns></returns>
	private bool AreAllFieldComplete()
	{
		string label = labelField.text;
		string id = idField.text;
		string password = passwordField.text;

		return !label.Equals("") && !id.Equals("") && !password.Equals("");
	}

	/// <summary>
	/// Set input field texts based on info.
	/// </summary>
	public void SetInfo(AccountInfo info)
	{
		this.info = info;

		if (info != null)
		{
			labelField.text = info.Label;
			idField.text = info.Id;
			passwordField.text = info.Password;
		}
	}

	/// <summary>
	/// Set interactibility of the valid button based on input field texts.
	/// </summary>
	public void CheckValidButton()
	{
		validBtn.interactable = AreAllFieldComplete();
	}

	/// <summary>
	/// Save the info with modification.
	/// </summary>
	public void Save()
	{
		string label = labelField.text;
		string id = idField.text;
		string password = passwordField.text;

		if (AreAllFieldComplete())
		{
			if (info == null)
			{
				info = new AccountInfo(label, id, password);
			}
			else
			{
				info.Label = label;
				info.Id = id;
				info.Password = password;
			}

			DataManager.AddInfo(info);

			mainCanvas.OnModification?.Invoke();

			gameObject.SetActive(false);
		}
	}
}
