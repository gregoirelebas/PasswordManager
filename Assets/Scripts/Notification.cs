using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum NotificationType
{
	WrongPassword,
	NewPassword,
	AllDataClear,
}

[System.Serializable]
public class NotificationLocalizedText
{
	public string englishText = null;
	public string frenchText = null;

	public string GetString()
	{
		switch (MainCanvas.Instance.CurrentLang)
		{
			case Lang.English:
				return englishText;

			case Lang.French:
				return frenchText;

			default:
				Debug.LogWarning("Unknown lang : " + MainCanvas.Instance.CurrentLang.ToString() + ", setting english as default");
				return englishText;
		}
	}
}

public class Notification : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI notifText = null;

	[Header("LocalizedText")]
	[SerializeField] private NotificationLocalizedText wrongPassword = null;
	[SerializeField] private NotificationLocalizedText newPassword = null;
	[SerializeField] private NotificationLocalizedText allDataClear = null;

	private CanvasGroup group = null;

	private void Awake()
	{
		group = GetComponent<CanvasGroup>();
	}

	public void SetNotification(NotificationType notifType)
	{
		switch (notifType)
		{
			case NotificationType.WrongPassword:
				notifText.text = wrongPassword.GetString();
				break;

			case NotificationType.NewPassword:
				notifText.text = newPassword.GetString();
				break;

			case NotificationType.AllDataClear:
				notifText.text = allDataClear.GetString();
				break;

			default:
				Debug.LogWarning("Unknown notification type :" + notifType.ToString());
				break;
		}
	}
}
