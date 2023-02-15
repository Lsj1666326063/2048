using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private Map map;

    private void Awake()
    {
        map.InitGrid();
        
        map.RandomGenerateNum();
        map.RandomGenerateNum();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            map
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
}