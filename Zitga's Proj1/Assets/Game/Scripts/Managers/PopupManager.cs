using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : SingletonDontDestroy<PopupManager>
{
    [SerializeField] private Transform canvasPopup;
    public List<BasePopup> popups;
    private Dictionary<Type, BasePopup> popupDictionary = new Dictionary<Type, BasePopup>();
    private List<BasePopup> _listActive = new List<BasePopup>();
    private int _orderLayer = 0;
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach (var loadDiction in popups)
        {
            popupDictionary.Add(loadDiction.GetType(), loadDiction);
        }
    }
    public void ShowPopup<T>()
    {
        if (popupDictionary.TryGetValue(typeof(T), out BasePopup popup))
        {
            var checkPop = _listActive.Find(c => c.GetType() == popup.GetType());
            if (!_listActive.Contains(checkPop))
            {
                var ins = Instantiate(popup, canvasPopup);
                ins.CanvasPopup.sortingOrder = ++_orderLayer;
                ins.Show();
                _listActive.Add(ins);
            }
            else
            {
                checkPop.CanvasPopup.sortingOrder = ++_orderLayer;
                checkPop.Show();
            }
        }
    }
    public void HideAllPopups()
    {
        foreach (var popup in _listActive)
        {
            popup.Close();
        }
    }
    public BasePopup GetPopup<T>()
    {
        if (popupDictionary.TryGetValue(typeof(T), out BasePopup popup))
        {
            var checkPop = _listActive.Find(c => c.GetType() == popup.GetType());
            if (checkPop != null)
            {
                return checkPop;
            }
            else
            {
                Debug.Log("Popup was not found");
                return null;
            }
        }
        else
        {
            Debug.Log("Popup was not found");
            return null;
        }
    }
}
