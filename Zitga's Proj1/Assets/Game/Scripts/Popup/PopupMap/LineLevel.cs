using System.Collections;
using System.Collections.Generic;
using Pancake;
using UnityEngine;

public class LineLevel : MonoBehaviour
{
    [SerializeField] private int numberElement = 2;
    public int NumberElement { get => numberElement; private set => numberElement = value; }
    private int _nextElement;
    [SerializeField] private LevelUI levelUI;
    private bool _ischange;
    private int _maxLevel;
    public void Init(int getMaxLevel)
    {
        _maxLevel = getMaxLevel;
        for (int i = 0; i < numberElement; i++)
        {
            var level = Instantiate(levelUI, transform);
        }
    }
    public void SetupLevel(int maxLevelNumber, bool isEvenline, bool isReverse)
    {
        _nextElement = 0;
        _ischange = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            var getChild = transform.GetChild(i).GetComponent<LevelUI>();
            getChild.ResetLine();
            if (maxLevelNumber <= _maxLevel)
            {
                if (_nextElement < transform.childCount - 1)
                {
                    if (_ischange)
                    {
                        getChild.SetLineRight1();
                    }
                    else
                    {
                        getChild.SetLineRight();
                    }
                    _ischange = !_ischange;
                    _nextElement++;
                }

                if (isReverse)
                {
                    if (isEvenline)
                    {
                        if (i == transform.childCount - 1 && maxLevelNumber > numberElement)
                        {
                            getChild.SetLineDown();
                        }
                        getChild.Init(maxLevelNumber--);
                    }
                    else
                    {
                        if (i == 0 && maxLevelNumber > numberElement)
                        {
                            getChild.SetBothDownAndRight();
                        }
                        getChild.Init((maxLevelNumber - (numberElement - 1)) + i);
                    }
                }
                else
                {
                    if (isEvenline)
                    {
                        if (i == 0 && maxLevelNumber > numberElement)
                        {
                            getChild.SetBothDownAndRight();
                        }
                        getChild.Init((maxLevelNumber - (numberElement - 1)) + i);
                    }
                    else
                    {
                        if (i == transform.childCount - 1 && maxLevelNumber > numberElement)
                        {
                            getChild.SetLineDown();
                        }
                        getChild.Init(maxLevelNumber--);
                    }
                }
            }
            else
            {
                getChild.SetComingSoon();
            }
        }

    }

}
