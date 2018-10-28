using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	[SerializeField]protected string resourceName="Resource";
	[SerializeField]protected int minConstraint=0;
	[SerializeField]protected int maxConstraint=100;
	[SerializeField]protected static int count=0;
	[SerializeField]protected int mapHeight=10;
	[SerializeField]protected int mapWidth=10;
	[SerializeField]protected int footPrint=1;

	[SerializeField]protected GameObject[] prefab;
	[SerializeField]protected GameObject GroupHead;

	protected void IncreaseNumber(int dn=1)
	{
		count += dn;
	}

	protected void DecreaseNumber(int dn=1)
	{
		count -= dn;
	}

	protected void PlacePrefab(Vector3 pos)
	{
		int n = Random.Range (0,prefab.Length);
		GameObject obj=Instantiate (prefab [n], pos,Quaternion.identity);
		obj.transform.name = resourceName + count;
		obj.gameObject.transform.parent = GroupHead.transform;
	}

}
