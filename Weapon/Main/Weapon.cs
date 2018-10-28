using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	[SerializeField]protected int damage=10;
	[SerializeField]protected float range=2.5f;
	[SerializeField]protected Animator animator;
	[SerializeField]protected string[] animClips; 
	[SerializeField]protected AudioSource audioSource;
	[SerializeField]protected AudioClip[] audioClips;

	[SerializeField]protected GameObject firePoint; //Raycast fire

	protected void Attack ()
	{
		if (animClips.Length > 0)PlayAnimation (animClips,0,2);
		if (audioClips.Length > 0)PlayAudioClip (0);

		RaycastHit hit;
		Physics.Raycast (firePoint.transform.position,firePoint.transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity);

		if ((hit.distance < range) && (hit.collider.tag.Equals ("NonUsefulResource"))) {

			Debug.Log ("okay");
			hit.collider.gameObject.GetComponent<NonUsefulResource> ().TakeDamage (damage);

		} else
			return;
	}

	protected void PlayAnimation(string animationName="Idle")
	{
		animator.Play (animationName);
	}

	protected void PlayAnimation(string[] animationName,int startRand=0,int nRand=1,int layer=-1,float normalizedTime=0f)
	{
		int n = Random.Range (startRand,nRand);
		animator.Play (animationName[n], -1, 0f);	
	}

	protected void PlayAudioClip(int clipNo,float start,float end)
	{
		audioSource.clip = audioClips[clipNo];
		SoundSets.PlaySoundInterval (audioSource, start, end);
	}

	protected void PlayAudioClip(int clipNo)
	{
		audioSource.clip = audioClips[clipNo];
		SoundSets.PlaySoundInterval (audioSource,audioClips[clipNo]);
	}
		
}
