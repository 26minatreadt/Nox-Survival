using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[System.Serializable]
	public class SoundAudioClip
	{
		public string sound;
		public AudioClip audioClip;
	}

	public SoundAudioClip[] soundAudioClips;

	public void PlaySound(string sound)
	{
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		audioSource.clip = GetAudioClip(sound);
		audioSource.Play();
		Object.Destroy(soundGameObject, audioSource.clip.length);
	}

	private AudioClip GetAudioClip(string sound)
	{
		foreach (SoundAudioClip soundAudioClip in soundAudioClips)
		{
			if (soundAudioClip.sound == sound)
				return soundAudioClip.audioClip;
		}
		return null;
	}
}
