using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPanel : MonoBehaviour
{
	[SerializeField] private Transform container = null;

	[SerializeField] private GameObject accountBtnPrefab = null;

	private MainCanvas mainCanvas = null;

	private void Awake()
	{
		mainCanvas = GetComponentInParent<MainCanvas>();
		mainCanvas.OnModification += UpdateInfoList;
	}

	private void OnEnable()
	{
		UpdateInfoList();
	}

	/// <summary>
	/// Delete all buttons of container and create new buttons using AccountInfo.
	/// </summary>
	public void UpdateInfoList()
	{
		for (int i = 0; i < container.childCount; i++)
		{
			Destroy(container.GetChild(i).gameObject);
		}

		foreach (AccountInfo info in DataManager.GetAllInfos())
		{
			AccountBtn newButton = Instantiate(accountBtnPrefab, container).GetComponent<AccountBtn>();

			newButton.SetAccountInfo(mainCanvas, info);
		}
	}
}
