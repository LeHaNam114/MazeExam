using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Config/BackGround")]
public class BackGroundData : ScriptableObject
{
    public List<BackGroundInfor> BackGroundInfors;
}
[Serializable]
public class BackGroundInfor
{
    public ETypeBackGround typeBackGround;
    public Sprite icon;
}
public enum ETypeBackGround
{
    BackGround1,
    BackGround2,
    BackGround3,
    BackGround4,
    BackGround5,
    BackGround6,
    BackGround7,
    BackGround8,
}
