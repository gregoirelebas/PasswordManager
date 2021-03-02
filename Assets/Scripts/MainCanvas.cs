using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
	[SerializeField] private Transform container = null;
    [SerializeField] private InfoPanel infoPanel = null;

	[SerializeField] private GameObject accountBtnPrefab = null;

	private List<AccountInfo> infos = new List<AccountInfo>();

	private void Awake()
	{
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));

		for (int i = 0; i < container.childCount; i++)
		{
			Destroy(container.GetChild(i).gameObject);
		}

		foreach (AccountInfo info in infos)
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
