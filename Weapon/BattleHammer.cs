using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHammer : WeaponClass {

	void Start()
	{
		if (animClips.Length <= 0)return;

		PlayAnimation (animClips[0]);	
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Attack (1,1,0);
		}
	}
}
