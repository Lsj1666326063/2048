using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public Text text;
    
    private Map map;

    private void Awake()
    {
        map = new Map();
        map.InitGrid(4);
        
        map.RandomGenerateNum();
        map.RandomGenerateNum();
        
        text.text = map.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void MoveUp()
    {
        map.MoveUp();
        text.text = map.ToString();
    }

    private void MoveDown()
    {
        map.MoveDown();
        text.text = map.ToString();
    }

    private void MoveLeft()
    {
        map.MoveLeft();
        text.text = map.ToString();
    }

    private void MoveRight()
    {
        map.MoveRight();
        text.text = map.ToString();
    }
}