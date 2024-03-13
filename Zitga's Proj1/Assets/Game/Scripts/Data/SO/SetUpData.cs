using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Config/SetUpGame")]
public class SetUpData : ScriptableObject
{
    [Header("LevelConfig")]
    public int maxLevel;
}
