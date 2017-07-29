using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public static SoundManager INSTANCE;

    public float Volume;

	//audio sources
	public AudioSource BossIncoming;

    float lowPitch = 0.8f;
	float highPitch = 1.2f;

	float lowVolume = 0.6f;
	float highVolume = 1f;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		if (INSTANCE == null){
			INSTANCE = GameObject.FindObjectOfType <SoundManager>().GetComponent <SoundManager>();
		}
			
	}

	public void PlayBossIncoming(){
		BossIncoming.PlayOneShot(BossIncoming.clip);
	}


    //tools
    void BendPitch(AudioSource source){
		source.pitch = Random.Range (lowPitch, highPitch);
	}

	void BendVolume(AudioSource source){
		source.volume = Random.Range (lowVolume, highVolume);
	}

	void SetVolume(AudioSource source, float value){
		source.volume = value;
	}

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return new WaitForEndOfFrame();
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
