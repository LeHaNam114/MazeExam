using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private BackGroundData backGroundData;
    [SerializeField] private List<SpriteRenderer> subBGs;
    private Sprite _getCurrentBG;
    private void Start()
    {
        try
        {
            _getCurrentBG = backGroundData.BackGroundInfors.Find(c => c.typeBackGround == LevelController.Instance.typeBackGround).icon;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        foreach (var subBg in subBGs)
        {
            subBg.sprite = _getCurrentBG;
        }
    }
}
