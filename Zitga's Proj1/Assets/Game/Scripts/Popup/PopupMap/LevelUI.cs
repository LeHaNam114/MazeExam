using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = Pancake.Random;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private RectTransform star;
    [SerializeField] private Image lockImg;
    [SerializeField] private Image lineRight;
    [SerializeField] private Image lineDown;
    [SerializeField] private Image lineRight2;
    [SerializeField] private Image tutorial;
    public void Init(int levelIndex)
    {
        textLevel.text = levelIndex.ToString();
        Data.CurrentLevel = levelIndex;
        SetTutorial(false);
        if (levelIndex <= Data.LevelUnlock)
        {
            GetRandomStar();
            SetUnlock(true);
            if (levelIndex == 1)
            {
                SetTutorial(true);
            }
        }
        else
        {
            SetUnlock(false);
            ResetStar();
        }
    }
    void SetTutorial(bool istutorial)
    {
        tutorial.gameObject.SetActive(istutorial);
        textLevel.gameObject.SetActive(!istutorial);
    }

    void GetRandomStar()
    {
        ResetStar();
        for (int i = 0; i < Data.GetStarPerLevel(Data.CurrentLevel); i++)
        {
            star.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    void ResetStar()
    {
        for (int i = 0; i < star.childCount; i++)
        {
            star.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SetLineRight()
    {
        SetLine(true, false, false);
    }
    void SetLine(bool isLineRight, bool isLineRight2, bool isLightDown)
    {
        lineRight.gameObject.SetActive(isLineRight);
        lineRight2.gameObject.SetActive(isLineRight2);
        lineDown.gameObject.SetActive(isLightDown);
    }
    public void SetLineRight1()
    {
        SetLine(false, true, false);
    }
    public void SetLineDown()
    {

        SetLine(false, false, true);
    }
    public void SetBothDownAndRight()
    {

        SetLine(true, false, true);
    }
    public void SetComingSoon()
    {
        ResetLine();
        textLevel.text = "Coming Soon";
    }
    public void ResetLine()
    {
        SetLine(false, false, false);
    }
    public void SetUnlock(bool isUnlock)
    {
        lockImg.gameObject.SetActive(!isUnlock);
    }
    public void PlayLevel()
    {
        Load.LoadSceneWithoutTrans(Constant.GamePlayScene);
    }
}
