//Some Functions related to sounds

using UnityEngine;
struct SoundSets
{
	public static void PlaySoundInterval(AudioSource audioSource,AudioClip clip)
	{
		audioSource.PlayOneShot (clip);
	}

	public static void PlaySoundInterval(AudioSource audioSource,float fromSeconds, float toSeconds)
	{
		audioSource.time = fromSeconds;
		audioSource.Play ();
		audioSource.SetScheduledEndTime (AudioSettings.dspTime + (toSeconds - fromSeconds));
	}
}