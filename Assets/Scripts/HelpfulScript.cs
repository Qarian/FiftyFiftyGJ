using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpfulScript : MonoBehaviour
{
	[SerializeField]
	GlobalVariables globalVariables = default;

    public void CopyAndActivate(GameObject go)
	{
		Instantiate(go, go.transform.position, go.transform.rotation).SetActive(true);
	}

	public void IncreaseGlobalVariable(string name)
	{
		for (int i = 0; i < globalVariables.values.Count; i++)
		{
			if (globalVariables.values[i].name == name)
			{
				globalVariables.values[i].number++;
				return;
			}
		}
	}

	public void DecreaseGlobalVariable(string name)
	{
		for (int i = 0; i < globalVariables.values.Count; i++)
		{
			if (globalVariables.values[i].name == name)
			{
				globalVariables.values[i].number--;
				return;
			}
		}
	}
}
