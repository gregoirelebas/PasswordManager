using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public static class DataManager
{
	private static Dictionary<string, AccountInfo> infos = new Dictionary<string, AccountInfo>();

	public static string EncryptionKey = "";

	public static int KeyIndex { get; private set; } = 0;
	public const string NoKey = "NoKey";

	public const string DirectoryName = "Data";
	public const string FileName = "data.json";

	public static bool IsUnlocked = false;

	#region Encryption

	/// <summary> 
	///Encrypt a byte array into a byte array using a key and an IV.
	/// </summary>
	public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
	{
		MemoryStream ms = new MemoryStream();

		Rijndael alg = Rijndael.Create();

		alg.Key = Key;
		alg.IV = IV;

		using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
		{
			cs.Write(clearData, 0, clearData.Length);
		}

		byte[] encryptedData = ms.ToArray();

		return encryptedData;
	}

	/// <summary>
	/// Encrypt a string into a crypted string using a password.
	/// </summary>
	public static string Encrypt(string clearText, string Password)
	{
		byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);

		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

		byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

		return System.Convert.ToBase64String(encryptedData);
	}

	/// <summary>
	/// Decrypt a byte array into a byte array using a key and an IV.
	/// </summary>
	public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
	{
		MemoryStream ms = new MemoryStream();

		Rijndael alg = Rijndael.Create();

		alg.Key = Key;
		alg.IV = IV;

		using (CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write))
		{
			cs.Write(cipherData, 0, cipherData.Length);
		}

		byte[] decryptedData = ms.ToArray();

		return decryptedData;
	}

	/// <summary>
	/// Encrypt a string into a crypted string and a password.
	/// </summary>
	public static string Decrypt(string cipherText, string Password)
	{
		byte[] cipherBytes = System.Convert.FromBase64String(cipherText);

		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

		byte[] decryptedData = Decrypt(cipherBytes,
			pdb.GetBytes(32), pdb.GetBytes(16));

		return System.Text.Encoding.Unicode.GetString(decryptedData);
	}

	#endregion

	/// <summary>
	/// Try to read the JSON file and load data is success.
	/// </summary>
	private static void LoadData()
	{
		KeyIndex = PlayerPrefs.GetInt("DataKeyIndex", 0);

		string dirPath = Application.persistentDataPath + "/" + DirectoryName;

		if (Directory.Exists(dirPath))
		{
			string filePath = dirPath += "/" + FileName;
			if (File.Exists(filePath))
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string jsonData = reader.ReadToEnd();
					infos = JsonConvert.DeserializeObject<Dictionary<string, AccountInfo>>(jsonData);

					Debug.Log("Raw JSONData : " + jsonData);
				}
			}
			else
			{
				Debug.Log("File not found : " + filePath);
			}
		}
		else
		{
			Debug.Log("Folder not found : " + dirPath);
		}
	}

	/// <summary>
	/// Save all data in a JSON file. Write over all data.
	/// </summary>
	public static void SaveData()
	{
		PlayerPrefs.SetInt("DataKeyIndex", KeyIndex);
		PlayerPrefs.Save();

		string dirPath = Application.persistentDataPath + "/" + DirectoryName;

		if (!Directory.Exists(dirPath))
		{
			Directory.CreateDirectory(dirPath);

			Debug.Log("Created directory : " + dirPath);
		}

		string filePath = dirPath += "/" + FileName;

		string jsonData = JsonConvert.SerializeObject(infos);

		FileStream fileStream = File.Open(filePath, FileMode.Create);
		using (StreamWriter writer = new StreamWriter(fileStream))
		{
			writer.WriteLine(jsonData);
		}
	}

	/// <summary>
	/// Fill the dictionary with debug data.
	/// </summary>
	public static void Initialize()
	{
		infos = new Dictionary<string, AccountInfo>();

		EncryptionKey = PlayerPrefs.GetString("EncryptionKey", "");

		LoadData();
	}

	/// <summary>
	/// Return the AccountInfo linked to the key.
	/// </summary>
	public static AccountInfo GetInfo(string key)
	{
		AccountInfo info;
		infos.TryGetValue(key, out info);

		return info;
	}

	/// <summary>
	/// Return all infos as a List<AccountInfo>.
	/// </summary>
	public static List<AccountInfo> GetAllInfos()
	{
		return infos.Values.ToList();
	}

	/// <summary>
	/// Try to add a new AccountInfo to dictionary. Create a key if none exist or call Modify() if key already exist.
	/// </summary>
	public static void AddInfo(AccountInfo info)
	{
		if (info.Key.Equals(NoKey))
		{
			info.Key = "DataKey_0" + KeyIndex;

			KeyIndex++;
		}

		if (EncryptionKey.Equals(""))
		{
			EncryptionKey = info.Label;

			PlayerPrefs.SetString("EncryptionKey", EncryptionKey);
			PlayerPrefs.Save();
		}

		info.Id = Encrypt(info.Id, EncryptionKey);
		info.Password = Encrypt(info.Password, EncryptionKey);

		if (!infos.ContainsKey(info.Key))
		{
			infos.Add(info.Key, info);
		}
		else
		{
			ModifyInfo(info);
		}
	}

	/// <summary>
	/// Modify an existing AccountInfo. Call Add() if key don't exist or not in dictionary.
	/// </summary>
	public static void ModifyInfo(AccountInfo info)
	{
		if (!info.Key.Equals(NoKey) && infos.ContainsKey(info.Key))
		{
			infos[info.Key] = info;
		}
		else
		{
			AddInfo(info);
		}
	}

	/// <summary>
	/// Remove the AccountInfo from the dictionary.
	/// </summary>
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

	public static void DeleteAllInfos()
	{
		infos.Clear();

		KeyIndex = 0;

		SaveData();
	}
}
