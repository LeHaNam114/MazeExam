using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonDontDestroy<SoundManager>
{
    [SerializeField] private AudioSource AudioBG;
    [SerializeField] private AudioSource AudioOneShot;
    [SerializeField] private SoundData soundData;
    private void UpdateSoundSystem()
    {
        AudioBG.mute = Data.IsMuteSoundBG;
        AudioOneShot.mute = Data.IsMuteSoundOneShot;
    }
    public void PLayAudioOneShot(TypeoOfSound audioType)
    {
        if (SearchAudio(audioType!)!=null)
        {
            AudioOneShot.loop = false;
            AudioOneShot.PlayOneShot(SearchAudio(audioType));
        }
        else
        {
            Debug.LogError("No AudioCLip");
        }
    }
    public void PLayAudioContinously(TypeoOfSound audioType)
    {
        if (SearchAudio(audioType!)!=null)
        {
            AudioOneShot.loop = true;
            AudioOneShot.clip = SearchAudio(audioType);
            AudioOneShot.Play();
        }
        else
        {
            Debug.LogError("No AudioCLip");
        }
    }
    
    public void PLayAudioBG(TypeoOfSound audioType)
    {
        if (SearchAudio(audioType)!=null)
        {
            AudioBG.clip = SearchAudio(audioType);
            AudioBG.Play();
        }
        else
        {
            Debug.LogError("No AudioCLip");
        }
    }
    AudioClip SearchAudio(TypeoOfSound audioType)
    {
        try
        {
            var getAudioClip = soundData.sound.Find(item => item.Type == audioType).sound;
            return getAudioClip;
        }
        catch (Exception e)
        {
            Debug.LogError("Type Sound was not found");
            return null;
        }
    }
    
}
