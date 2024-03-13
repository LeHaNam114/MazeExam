using System.Collections;
using System.Collections.Generic;
using Pancake;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ShowStageMode()
    {
        PopupManager.Instance.ShowPopup<RecycleScrollMap>();
    }
}
