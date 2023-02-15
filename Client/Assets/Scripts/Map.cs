using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Grid[,] grids;

    public void InitGrid(int size)
    {
        grids = new Grid[size,size];

        int rows = grids.GetLength(0);
        int cols = grids.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grids[i,j] = new Grid();
            }
        }
        
    }

    public void RandomGenerateNum()
    {
        
    }

    public void MoveNum(MoveDir dir)
    {
        
    }
}


/*
    二维数组 结合下方不同的观察方式，用行和列来理解比较清晰，不能用 x,y 来理解

    // {
    //     {1,1,1,1},
    //     {1,1,1,1}
    // };

    // { {1,1,1,1}, {1,1,1,1} };
*/
