using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyPanel : MonoBehaviour
{
	[SerializeField] private Transform keyContainer = null;

	private KeyBtn[] keys = null;

	private void Awake()
	{
		keys = keyContainer.GetComponentsInChildren<KeyBtn>();

		List<int> keyValues = new List<int>();
		for (int i = 0; i < keys.Length; i++)
		{
			keyValues.Add(i + 1);
		}

		System.Random rnd = new System.Random();
		keyValues = keyValues.OrderBy(x => rnd.Next()).ToList();

		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].SetValue(keyValues[i]);
		}
	}
}
