using System;
using System.Collections;
using System.Collections.Generic;
using Pancake;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = Pancake.Random;

public class RecycleScrollMap : BasePopup
{
    [SerializeField] private LineLevel lineLevel;
    [SerializeField] private RectTransform content;
    [SerializeField] private GridLayoutGroup gridContent;
    [SerializeField] private int levelAmount;
    [SerializeField] private TextMeshProUGUI totalStarText;
    private Canvas _popupCanvas => gameObject.GetComponentInParent<Canvas>();
    private List<LineLevel> poolLine = new List<LineLevel>();
    private int _numberofLine;
    private Vector3 _prevMousePos;
    private bool _isDrag;
    private bool _isRecycle;
    private float _contentLength;
    private int _reverse = 1;
    private int timeRecycle = 1;
    private int _maxline;
    private bool _isMaxlevel;
    private int _lineMax;
    private bool _isCanRun;
    [SerializeField, Range(1, 100)] private float sensitive;

    protected override void Initialization()
    {
        Init();
        base.Initialization();
    }
    void Init()
    {
        if (Data.LevelUnlock == default)
        {
            SetupRandom();
        }
        totalStarText.text = Data.TotalStar.ToString();
        content.anchoredPosition3D = Vector3.zero;
        _numberofLine = levelAmount / lineLevel.NumberElement;
        _maxline = 2 * Mathf.CeilToInt(content.rect.height / (gridContent.spacing.y + gridContent.cellSize.y));
        _isRecycle = _numberofLine > _maxline;
        for (int i = 0; i < _maxline; i++)
        {
            var line = Instantiate(lineLevel, content.transform);
            line.Init(levelAmount);
            _contentLength += gridContent.spacing.y + gridContent.cellSize.y;
            poolLine.Add(line);
        }
        SetUpLevel();
        _isCanRun = true;

    }
    public void Reset()
    {
        SetupRandom();
        SetUpLevel();
        totalStarText.text = Data.TotalStar.ToString();
    }
    void SetupRandom()
    {
        var rand = Random.Range(1, levelAmount);
        Data.TotalStar = default;
        Data.LevelUnlock = rand;
        for (int i = 1; i <= rand; i++)
        {
            var ranStar = Random.Range(1, 4);
            Data.SetStarPerLevel(i, ranStar);
            Data.TotalStar += ranStar;
        }
    }
    private void Update()
    {
        if (_isCanRun)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _isDrag = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _prevMousePos = _popupCanvas.worldCamera.ScreenToWorldPoint(Input.mousePosition);
                _isDrag = true;
            }

        }
    }
    void SetUpLevel()
    {
        for (int i = 1; i <= poolLine.Count; i++)
        {
            var maxLevelPerLine = lineLevel.NumberElement * ((i - 1) + timeRecycle);
            poolLine[poolLine.Count - i].SetupLevel(maxLevelPerLine, i % 2 == 0, _reverse > 0);
            if (maxLevelPerLine == levelAmount)
            {
                _isMaxlevel = true;
                _lineMax = i;
            }
        }
    }
    private void LateUpdate()
    {
        if (_isDrag)
        {
            var pos = _popupCanvas.worldCamera.ScreenToWorldPoint(Input.mousePosition);
            if (pos != _prevMousePos)
            {
                var distance = _prevMousePos.y - pos.y;
                content.anchoredPosition3D = new Vector3(content.anchoredPosition3D.x, content.anchoredPosition3D.y - distance * (gridContent.cellSize.y + sensitive), content.anchoredPosition3D.z);
                if (_isRecycle)
                {
                    if (distance >= 0)
                    {
                        SrcollUp();
                    }
                    else
                    {
                        ScrollDown();
                    }

                }
                _prevMousePos = pos;
            }
        }

    }
    void SrcollUp()
    {
        if (_isMaxlevel)
        {
            if (_lineMax <= _maxline / 2)
            {
                content.anchoredPosition3D = Vector3.zero;
            }
            else
            {
                int maxShow = Mathf.CeilToInt(content.rect.height / (gridContent.spacing.y + gridContent.cellSize.y));
                var spacelimit = (_lineMax - maxShow) * (gridContent.spacing.y + gridContent.cellSize.y);
                if (content.anchoredPosition3D.y <= -spacelimit)
                {
                    content.anchoredPosition3D = new Vector3(content.anchoredPosition3D.x, -spacelimit, content.anchoredPosition3D.z);
                }
            }
        }
        else
        {
            if (content.anchoredPosition3D.y <= -(_contentLength / 2 - (gridContent.spacing.y + gridContent.cellSize.y)))
            {
                {
                    timeRecycle += _maxline / 2 - 1;
                    _reverse *= (_maxline / 2) % 2 == 0 ? -1 : 1;
                    content.anchoredPosition3D = Vector3.zero;
                    SetUpLevel();
                }
            }
        }

    }
    void ScrollDown()
    {
        if (content.anchoredPosition3D.y > 0)
        {
            if (timeRecycle == 1)
            {
                content.anchoredPosition3D = Vector3.zero;
            }
            else
            {
                content.anchoredPosition3D = new Vector3(content.anchoredPosition3D.x, content.anchoredPosition3D.y - (_contentLength / 2 - gridContent.spacing.y - gridContent.cellSize.y));
                timeRecycle -= _maxline / 2 - 1;
                _isMaxlevel = false;
                _reverse *= (_maxline / 2) % 2 == 0 ? -1 : 1;
                SetUpLevel();
            }
        }
    }

}
