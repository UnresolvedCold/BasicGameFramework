﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : WeaponClass {

	[SerializeField] private int defaultIdleAnim = 0;

	void Start()
	{
		if (animClips.Length <= 0)return;

		PlayAnimation (animClips[defaultIdleAnim]);	
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Attack (1,2,0);
		}
	}
}
