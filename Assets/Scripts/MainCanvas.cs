using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
	[SerializeField] private Transform container = null;
    [SerializeField] private InfoPanel infoPanel = null;

	[SerializeField] private GameObject accountBtnPrefab = null;

	private void Awake()
	{
		DataManager.Initialize();

		for (int i = 0; i < container.childCount; i++)
		{
			Destroy(container.GetChild(i).gameObject);
		}

		foreach (AccountInfo info in DataManager.GetAllInfos())
		{
			AccountBtn newButton = Instantiate(accountBtnPrefab, container).GetComponent<AccountBtn>();

			newButton.SetAccountInfo(this, info);
		}
	}

	public void DisplayInfoPanel(AccountInfo info)
	{
        infoPanel.gameObject.SetActive(true);
        infoPanel.SetInfos(info);
	}
}
