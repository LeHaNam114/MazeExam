using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject frontWall;
    public GameObject backWall;
    [SerializeField]
    private GameObject unvisitedBlock;
    public int posx;
    public int posz;
    public bool isVisited;
    public int mark;

    public void Visit()
    {
        isVisited = true;
        unvisitedBlock.SetActive(false);
    }
    public void SetMark(int getMark)
    {
        mark = getMark; 
    }

    public void ClearLeftWall()
    {
        leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        backWall.SetActive(false);
    }
}
