using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Resource : NonUsefulResource {

	void Start()
	{
		AttachResourceToGround ();
	}

	void Update()
	{
		//What to do before destruction of Resource

		if (health >= 0) return;

		//what to do after destruction of resource

		gameObject.transform.tag="Untagged"; //to avoid taking damage
		treeManager.DestroyTree ();
		StartCoroutine(GenerateUseful ());
		PlayAnimation ("TreeFall01");
		PlayAudioClip (0);

		//All codes must be above this line
		StartCoroutine (DestroyResource ());
	}


}
