using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DataManager
{
    private static Dictionary<string, AccountInfo> infos = new Dictionary<string, AccountInfo>();

    public static void Initialize()
	{
		infos.Add("Pinterest", new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("9GAG", new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Artstation", new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Linkedin", new AccountInfo("Linkedin", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Facebook", new AccountInfo("Facebook", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Twitter", new AccountInfo("Twitter", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Youtube", new AccountInfo("Youtube", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		infos.Add("Playstation", new AccountInfo("Playstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
	}

	public static AccountInfo GetInfo(string key)
	{
		AccountInfo info;
		infos.TryGetValue(key, out info);

		return info;
	}

	public static List<AccountInfo> GetAllInfos()
	{
		return infos.Values.ToList();
	}

	public static void AddInfo(AccountInfo info)
	{
		if (!infos.ContainsKey(info.Label))
		{
			infos.Add(info.Label, info);
		}
		else
		{
			ModifyInfo(info);
		}
	}

	public static void ModifyInfo(AccountInfo info)
	{
		if (infos.ContainsKey(info.Label))
		{
			infos[info.Label] = info;			
		}
		else
		{
			AddInfo(info);
		}
	}
}
