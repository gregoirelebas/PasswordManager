using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPanel : MonoBehaviour
{
	[SerializeField] private Transform container = null;

	[SerializeField] private GameObject accountBtnPrefab = null;

	private bool sortAscending = true;

	private void Awake()
	{
		MainCanvas.Instance.OnModification += UpdateInfoList;
	}

	private void OnEnable()
	{
		UpdateInfoList();
	}

	/// <summary>
	/// Sort by label name in alphabetical order.
	/// </summary>
	private int SortByNameAscending(AccountInfo a, AccountInfo b)
	{
		return a.Label.CompareTo(b.Label);
	}

	/// <summary>
	/// Sort by label name in reversed alphabetical order.
	/// </summary>
	private int SortByNameDescending(AccountInfo a, AccountInfo b)
	{
		return b.Label.CompareTo(a.Label);
	}

	/// <summary>
	/// Invert sorting system and update displayed list.
	/// </summary>
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

			newButton.SetAccountInfo(info);
		}
	}
}
