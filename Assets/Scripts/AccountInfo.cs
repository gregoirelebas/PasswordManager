﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountInfo
{
	public string Key { get; set; } = "";
	public string Label { get; set; } = "";
	public string Id { get; set; } = "";
	public string Password { get; set; } = "";

	public AccountInfo(string label, string id, string password)
	{
		Key = DataManager.NoKey;
		Label = label;
		Id = id;
		Password = password;
	}
}
