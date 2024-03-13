using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    #region Settings
    public static bool IsMuteSoundBG
    {
        get => GetBool(Constant.IsMuteSoundBg);
        set => SetBool(Constant.IsMuteSoundBg, value);
    }
    public static bool IsMuteSoundOneShot
    {
        get => GetBool(Constant.IsMuteSoundOneShot);
        set => SetBool(Constant.IsMuteSoundOneShot, value);
    }
    #endregion
    #region LoadCondition
    public static string SceneToLoad;
    public static bool IsTransforLoadingScene = false;
    #endregion
    #region GamePlay
    public static int CurrentLevel
    {
        get => GetInt(Constant.Level, 1);
        set => SetInt(Constant.Level, value);
    }
    public static int LevelUnlock
    {
        get => GetInt(Constant.LevelUnlocked, 0);
        set => SetInt(Constant.LevelUnlocked, value);
    }
    public static int TotalStar
    {
        get => GetInt(Constant.TotalStar, 0);
        set => SetInt(Constant.TotalStar, value);
    }
    public static int GetStarPerLevel(int indexLevel)
    {
        return GetInt(indexLevel.ToString(), 0);
    }
    public static void SetStarPerLevel(int indexLevel, int value)
    {
        SetInt(indexLevel.ToString(), value);
    }
    #endregion
    
    #region CustomValue
    private static bool GetBool(string key, bool defaultValue = false) =>
        PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;

    private static void SetBool(string id, bool value) => PlayerPrefs.SetInt(id, value ? 1 : 0);

    private static int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
    private static void SetInt(string id, int value) => PlayerPrefs.SetInt(id, value);

    private static string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);
    private static void SetString(string id, string value) => PlayerPrefs.SetString(id, value);
    #endregion
}
