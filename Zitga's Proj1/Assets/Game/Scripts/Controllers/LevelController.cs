using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  public ETypeBackGround typeBackGround;
  public static LevelController Instance;
  private void Awake()
  {
    Instance = this;
  }
}
