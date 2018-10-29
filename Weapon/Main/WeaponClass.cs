/*
 * Animation Clips must be arranged as 
 * 0 = Standing
 * 1-n = Attacking
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass : MonoBehaviour {

	[SerializeField]protected int damage=10;
	[SerializeField]protected float range=2.5f;
	[SerializeField]protected Animator animator;
	[SerializeField]protected string[] animClips; 
	[SerializeField]protected AudioSource audioSource;
	[SerializeField]protected AudioClip[] audioClips;

	[SerializeField]protected GameObject firePoint; //Raycast fire

	protected void Attack (int randomAnimationAttackclipStart=1,int randomAnimationAttackClipNumber=1,int randomAudioAttackClipNumber=0)
	{
		if (animClips.Length > 0)PlayAnimation (animClips,randomAnimationAttackclipStart,randomAnimationAttackClipNumber);
		if (audioClips.Length > 0)PlayAudioClip (randomAudioAttackClipNumber);

		RaycastHit hit;
		Physics.Raycast (firePoint.transform.position,firePoint.transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity);

		if ((hit.distance < range) && (hit.collider.tag.Equals ("NonUsefulResource"))) {

			hit.collider.gameObject.GetComponent<NonUsefulResource> ().TakeDamage (damage);

		} else
			return;

		//for enemy code here
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
