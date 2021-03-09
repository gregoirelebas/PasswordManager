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

	[Header("Lerp values")]
	[SerializeField] private float startPos = 250.0f;
	[SerializeField] private float endPos = 350.0f;
	[SerializeField] private float lerpTime = 1.0f;

	[Header("LocalizedText")]
	[SerializeField] private NotificationLocalizedText wrongPassword = null;
	[SerializeField] private NotificationLocalizedText newPassword = null;
	[SerializeField] private NotificationLocalizedText allDataClear = null;

	private RectTransform rectTransform = null;
	private CanvasGroup group = null;

	private void Awake()
	{
		group = GetComponent<CanvasGroup>();
		rectTransform = GetComponent<RectTransform>();
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

		LeanTween.value(1.0f, 0.0f, lerpTime).setOnUpdate((float alpha) =>
		{
			group.alpha = alpha;
		});

		LeanTween.value(startPos, endPos, lerpTime).setOnUpdate((float newPos) =>
		{
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newPos);
		}).setOnComplete(() =>
		{
			Destroy(gameObject);
		});
	}
}
