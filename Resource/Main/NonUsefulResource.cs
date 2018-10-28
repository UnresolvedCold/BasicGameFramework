/*
 * CheckHealth() Functions Requires Coroutine
 * GenerateUseful() Function Requires Coroutine
 * 
 * List Of Functions
 * DestroyResorce()	-IEnumerator
 * PlayAnimation(string nameOfAnimation)	-void
 * PlayAudioClip(int clipNoFromArray,float startTime,float endTime)	-void
 * GenerateUseful()	-IEnumerator
 * TakeDamage(int howMuchDamage)	-void	-public
 * 
 * More Developement is required in TakeDamage
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonUsefulResource : Resource {
	
	[SerializeField]protected GameObject usefulResourceProduced; //Reference to prefab of useful resource

	protected GameObject refToUseful; //reference to instantiated object

	protected IEnumerator GenerateUseful()
	{
		yield return new WaitForSeconds (timeForFullDestruction);
		refToUseful = Instantiate (usefulResourceProduced);
		refToUseful.transform.position = this.transform.position;
	}
		
	public void TakeDamage(int dn)
	{
		float n = (int)(Random.Range(0,10)%3);
		PlayAudioClip (1,n,n+0.5f);

		health -= dn;
	}
}
