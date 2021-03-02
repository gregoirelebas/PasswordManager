﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DataManager
{
	private static Dictionary<string, AccountInfo> infos = new Dictionary<string, AccountInfo>();

	public static int KeyIndex { get; private set; } = 0;
	public const string NoKey = "NoKey";

	public static void Initialize()
	{
		AddInfo(new AccountInfo("Pinterest", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("9GAG", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Artstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Linkedin", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Facebook", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Twitter", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Youtube", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
		AddInfo(new AccountInfo("Playstation", "gregoire.lebas@gmail.com", "123456789ABCDEF"));
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
		if (info.Key.Equals(NoKey))
		{
			info.Key = "DataKey_0" + KeyIndex;

			KeyIndex++;
		}

		if (!infos.ContainsKey(info.Key))
		{
			infos.Add(info.Key, info);
		}
		else
		{
			ModifyInfo(info);
		}
	}

	public static void ModifyInfo(AccountInfo info)
	{
		if (infos.ContainsKey(info.Key))
		{
			infos[info.Key] = info;
		}
		else
		{
			AddInfo(info);
		}
	}

	public static void DeleteInfo(AccountInfo info)
	{
		if (infos.ContainsKey(info.Key))
		{
			infos.Remove(info.Key);
		}
		else
		{
			Debug.LogError("Infos do not contains key, can't delete : " + info.Label);
		}
	}
}