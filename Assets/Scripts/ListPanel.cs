using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPanel : MonoBehaviour
{
	[SerializeField] private Transform container = null;

	[SerializeField] private GameObject accountBtnPrefab = null;

	private MainCanvas mainCanvas = null;
	private bool sortAscending = true;

	private void Awake()
	{
		mainCanvas = GetComponentInParent<MainCanvas>();
		mainCanvas.OnModification += UpdateInfoList;
	}

	private void OnEnable()
	{
		UpdateInfoList();
	}

	private int SortByNameAscending(AccountInfo a, AccountInfo b)
	{
		return a.Label.CompareTo(b.Label);
	}

	private int SortByNameDescending(AccountInfo a, AccountInfo b)
	{
		return b.Label.CompareTo(a.Label);
	}

	public void InvertSort()
	{
		sortAscending = !sortAscending;

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

		List<AccountInfo> infos = DataManager.GetAllInfos();

		if (sortAscending)
		{
			infos.Sort(SortByNameAscending);
		}
		else
		{
			infos.Sort(SortByNameDescending);
		}

		foreach (AccountInfo info in infos)
		{
			AccountBtn newButton = Instantiate(accountBtnPrefab, container).GetComponent<AccountBtn>();

			newButton.SetAccountInfo(mainCanvas, info);
		}
	}
}
