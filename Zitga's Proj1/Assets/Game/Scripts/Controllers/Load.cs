using System;
using System.Collections;
using System.Collections.Generic;
using Pancake.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Load
{
    public static bool isLoading=true;
    public static void  LoadSceneWithoutTrans(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static async UniTask LoadSceneAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        isLoading = false;
    }
    public static void DoTransitionLoading(string sceneName)
    {
        Data.SceneToLoad = sceneName;
        PopupManager.Instance.HideAllPopups();
        Data.IsTransforLoadingScene = true;
        PopupManager.Instance.ShowPopup<PopupTransition>();
    }
    
}
