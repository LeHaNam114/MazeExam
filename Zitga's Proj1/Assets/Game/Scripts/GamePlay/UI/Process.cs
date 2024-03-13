using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Process : MonoBehaviour
{
    [SerializeField] private Image processLine;
    [SerializeField] private Color lockedStar;
    [SerializeField] Color unlockedStar;
    [SerializeField] private RectTransform firstStar;
    [SerializeField] private RectTransform secondStar;
    [SerializeField] private RectTransform thirdStar;
    private int _maxTime = 30;
    private Sequence _sequence;
    private Guid _uid;
    private int _getStar=0;
    private void OnEnable()
    {
        Observer.StartLevel += StartLevel;
        Observer.FinishLevel += FinishLevel;
        Reset(firstStar);
        Reset(secondStar);
        Reset(thirdStar);
    }
    private void OnDisable()
    {
        Observer.StartLevel -= StartLevel;
        Observer.FinishLevel -= FinishLevel;
    }
    void StartLevel()
    {
        if (_sequence == null)
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(processLine.DOFillAmount(1, _maxTime).SetEase(Ease.Linear).OnUpdate((() =>
            {
                if (processLine.fillAmount > 0)
                {
                    _getStar += 1;
                    UnlockStar(firstStar);
                }
                if (processLine.fillAmount >= 0.5f)
                {
                    _getStar += 2;
                    UnlockStar(secondStar);
                }
                if (processLine.fillAmount >= 0.75f)
                {
                    _getStar += 3;
                    UnlockStar(thirdStar);
                }
            })));
            _uid = System.Guid.NewGuid();
            _sequence.id = _uid;
        }

    }
    void FinishLevel()
    {
        DOTween.Kill(_uid);
        _sequence = null;
    }
    void Reset(RectTransform starParent)
    {
        for (int i = 0; i < starParent.childCount; i++)
        {
            starParent.GetChild(i).GetComponent<Image>().color = lockedStar;
        }
    }
    void UnlockStar(RectTransform starParent)
    {
        for (int i = 0; i < starParent.childCount; i++)
        {
            starParent.GetChild(i).GetComponent<Image>().color = unlockedStar;
        }
    }

}
