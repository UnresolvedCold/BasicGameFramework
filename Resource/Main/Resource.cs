/*
 * Resource must have a tree structure
 * A
 * --B
 * 
 * A= Holder of resource  | Allscripts must be attached to A
 * B=Resource itself	  | Animator must be attached to B and not A
 * 
 * Required Components that must be attached to the Game Object
 * 1. Animator
 * 2.Audio Source
 *   --for audioSource to work audio clip must be added to array of clips
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	[SerializeField]protected TreeManager treeManager;

	[SerializeField]protected string resourceName="Resource";
	[SerializeField]protected int health=100;
	[SerializeField]protected float timeForFullDestruction=25f;
	[SerializeField]protected float maxAltitudeForResource=10f;
	[SerializeField]protected float minAltitudeForResource=4.75f;

	[SerializeField]protected Animator animator=null;
	[SerializeField]protected AudioSource audioSource = null;
	[SerializeField]protected AudioClip [] audioClip; 

	protected IEnumerator DestroyResource()
	{
		
		if (health < 0) {
			this.enabled = false;
			yield return new WaitForSeconds (timeForFullDestruction);
			Destroy (gameObject);
		}

	}

	protected void PlayAnimation(string animationName="Idle")
	{
		animator.Play (animationName);
	}

	protected void PlayAudioClip(int clipNo,float start,float end)
	{
		audioSource.clip = audioClip[clipNo];
		SoundSets.PlaySoundInterval (audioSource, start, end);
	}

	protected void PlayAudioClip(int clipNo)
	{
		audioSource.clip = audioClip[clipNo];
		SoundSets.PlaySoundInterval (audioSource,audioClip[clipNo]);
	}

	protected void AttachResourceToGround()
	{
		RaycastHit hit;
		if (Physics.Raycast (gameObject.transform.position, -1*transform.up, out hit, Mathf.Infinity)) {
			if (hit.collider.tag == "Terrain") {
				Vector3 pos = new Vector3 (0f, hit.distance, 0f);
				gameObject.transform.position -= pos;

				if (transform.position.y > maxAltitudeForResource || transform.position.y < minAltitudeForResource) {
					Destroy (gameObject);
					treeManager.DestroyTree ();
				}
			} else {
				Destroy (gameObject);
				treeManager.DestroyTree ();
			}
		}
	}
		
}
