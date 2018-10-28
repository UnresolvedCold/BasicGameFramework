using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulResource : Resource { 

	[SerializeField]protected float timeToDisplayAfterInit=10f;

	void Start () {
		Destroy (gameObject, timeToDisplayAfterInit);
	}

	void DestroyInSeconds(float time)
	{
		timeForFullDestruction = time;
		health = -1;
	}
}
