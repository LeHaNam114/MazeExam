using System;
using System.Collections;
using System.Collections.Generic;
using Pancake;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isDoneLoading => false;
    [SerializeField] private Transform level;
    private void Awake()
    {
        Instance = this;
        PopupManager.Instance.HideAllPopups();
        ShowLevel(Constant.Level, Data.CurrentLevel);
    }
    public void HomeBtn()
    {
        Load.LoadSceneWithoutTrans(Constant.MenuScene);
    }
    public void NextLeve()
    {
        SetUpLevel(true);
        Load.LoadSceneWithoutTrans(Constant.GamePlayScene);
    }
    public void PreLevel()
    {
        SetUpLevel(false);
        Load.LoadSceneWithoutTrans(Constant.GamePlayScene);
    }
    void SetUpLevel(bool isNextLevel)
    {
        int index = isNextLevel ? 1 : -1;
        Data.CurrentLevel += index;
    }
    public void PauseGame(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
    }
    #region LoadLevel
    [ReadOnly] public LevelController currentLevel;
    public void ShowLevel(string address, int indexLevel)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if (Data.CurrentLevel > ConfigController.Instance.SetUpData.maxLevel)
        {
            Data.CurrentLevel = 1;
            indexLevel = Data.CurrentLevel;
        }
        if (Data.CurrentLevel < 1)
        {
            Data.CurrentLevel = ConfigController.Instance.SetUpData.maxLevel;
            indexLevel = Data.CurrentLevel;
        }
        var getLevel = GetLevelController(address, indexLevel);
        currentLevel = Instantiate(getLevel, level);
        currentLevel.gameObject.SetActive(true);
    }
    public LevelController GetLevelController(string address, int indexLevel)
    {
        var levelGo = Resources.Load($"Levels/{address} {1}") as GameObject;
        Debug.Assert(levelGo != null, nameof(levelGo) + " != null");
        return levelGo.GetComponent<LevelController>();
    }
    #endregion
}
