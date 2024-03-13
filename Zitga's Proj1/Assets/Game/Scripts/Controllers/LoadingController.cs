using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Image fillBarLoading;
    [SerializeField] private TextMeshProUGUI textLoading;
    [SerializeField, Range(1, 10)] private float timeLoading;
    private AsyncOperation _loadNextScene;
    private void Start()
    {
        //SoundManager.Instance.PLayAudioBG(TypeoOfSound.SoundLoading);
        _loadNextScene = SceneManager.LoadSceneAsync(Constant.MenuScene);
        _loadNextScene.allowSceneActivation = false;
        LoadingBar();
    }
    void LoadingBar()
    {
        fillBarLoading.fillAmount = 0;
        fillBarLoading.DOFillAmount(1, timeLoading).OnUpdate((() =>
        {
            textLoading.text = $"Loading {(int)(fillBarLoading.fillAmount * 100)}%";
        })).OnComplete((() =>
        {
            LoadingCompleted();
        }));
    }
    void LoadingCompleted()
    {
        _loadNextScene.allowSceneActivation = true;
    }
}