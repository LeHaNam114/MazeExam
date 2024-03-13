using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Config/Sound")]
public class SoundData : ScriptableObject
{
    public List<SoundInfo> sound;
}
[Serializable]
public class SoundInfo
{
    public AudioClip sound;
    public TypeoOfSound Type;
}
public enum TypeoOfSound
{
    SoundLoading,
    SoundMenu,
    SoundGamePlay,
}
