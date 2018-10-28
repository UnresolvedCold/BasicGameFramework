using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : Manager {

	[SerializeField]private int randomRange=10;
	[SerializeField]private GameObject resourceDisplayGUI;

	void Start () {
		GenerateTreeForest ();
	}

	void Update () {

		resourceDisplayGUI.GetComponent<Text> ().text=count.ToString();

		if (count < minConstraint) {
			GenerateTreeForest ();
		}
		
	}

	void GenerateTreeForest()
	{
		for (float h = 0; h < mapHeight; h++) {
			for (float w = 0; w < mapWidth; w++) {

				if (count >= maxConstraint)
					return;

				float posX = Random.Range(-1*((mapWidth*footPrint)/2) + footPrint * w,mapWidth);
				float posZ = Random.Range(-1*((mapHeight*footPrint)/2) + footPrint * h,mapHeight);
				Vector3 pos = new Vector3 (posX,400,posZ);

				int r=Random.Range(0,randomRange);

				if (r==0 ){
					PlacePrefab (pos);
				}

				IncreaseNumber ();
			}
		}
	}

	public void DestroyTree()
	{
		DecreaseNumber ();
		Debug.Log (count);
	}
}
