using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Observer
{
    #region GamePLay
    public static Action StartLevel;
    public static Action FinishLevel;
    #endregion
    #region Loading
    public static Action<string> DoTransition;
    #endregion
}
