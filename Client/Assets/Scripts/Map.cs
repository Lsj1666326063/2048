using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Map
{
    public int[,] Nums;

    public void InitGrid(int size)
    {
        Nums = new int[size,size];

        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Nums[i,j] = new int();
            }
        }
    }

    public void RandomGenerateNum()
    {
        List<int> rowColList = new List<int>();
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (Nums[i, j] == 0)
                {
                    rowColList.Add(i*rows+j);
                }
            }
        }
        
        Random random = new Random();
        int index = random.Next(0, rowColList.Count);
        int row = rowColList[index] / rows;
        int col = rowColList[index] % rows;
        Nums[row, col] = 2;
    }

    public bool ClearZero(int[] _arr)
    {
        bool isClear = false;
        int index = 0;
        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i] != 0)
            {
                if (index != i)
                {
                    _arr[index] = _arr[i];
                    _arr[i] = 0;

                    isClear = true;
                }

                index++;
            }
        }

        return isClear;
    }

    public bool Combine(int[] _arr)
    {
        bool isCombine = false;
        for (int i = 0; i < _arr.Length-1; i++)
        {
            if (_arr[i] != 0 && _arr[i] == _arr[i + 1])
            {
                _arr[i] *= 2;
                _arr[i + 1] = 0;

                isCombine = true;
            }
        }

        return isCombine;
    }

    public void MoveUp()
    {
        bool isGenerateNewNum = false;
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < cols; i++)
        {
            int[] tempNums = new int[rows];
            for (int j = 0; j < rows; j++)
            {
                tempNums[j] = Nums[j, i];
            }
            
            bool isClear = ClearZero(tempNums);
            bool isCombine = Combine(tempNums);
            bool isClear1 = ClearZero(tempNums);
            if (!isGenerateNewNum)
                isGenerateNewNum = isClear || isCombine || isClear1;
            
            for (int j = 0; j < rows; j++)
            {
                Nums[j, i] = tempNums[j];
            }
        }
        
        if(isGenerateNewNum)
            RandomGenerateNum();
    }

    public void MoveDown()
    {
        bool isGenerateNewNum = false;
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < cols; i++)
        {
            int[] tempNums = new int[rows];
            for (int j = 0; j < rows; j++)
            {
                tempNums[j] = Nums[rows - (j + 1), i];
            }
            
            bool isClear = ClearZero(tempNums);
            bool isCombine = Combine(tempNums);
            bool isClear1 = ClearZero(tempNums);
            if (!isGenerateNewNum)
                isGenerateNewNum = isClear || isCombine || isClear1;
            
            for (int j = 0; j < rows; j++)
            {
                Nums[rows - (j + 1), i] = tempNums[j];
            }
        }
        
        if(isGenerateNewNum)
            RandomGenerateNum();
    }

    public void MoveLeft()
    {
        bool isGenerateNewNum = false;
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            int[] tempNums = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                tempNums[j] = Nums[i, j];
            }
            
            bool isClear = ClearZero(tempNums);
            bool isCombine = Combine(tempNums);
            bool isClear1 = ClearZero(tempNums);
            if (!isGenerateNewNum)
                isGenerateNewNum = isClear || isCombine || isClear1;
            
            for (int j = 0; j < cols; j++)
            {
                Nums[i, j] = tempNums[j];
            }
        }
        
        if(isGenerateNewNum)
            RandomGenerateNum();
    }

    public void MoveRight()
    {
        bool isGenerateNewNum = false;
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            int[] tempNums = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                tempNums[j] = Nums[i, cols - (j + 1)];
            }
            
            bool isClear = ClearZero(tempNums);
            bool isCombine = Combine(tempNums);
            bool isClear1 = ClearZero(tempNums);
            if (!isGenerateNewNum)
                isGenerateNewNum = isClear || isCombine || isClear1;
            
            for (int j = 0; j < cols; j++)
            {
                Nums[i, cols - (j + 1)] = tempNums[j];
            }
        }
        
        if(isGenerateNewNum)
            RandomGenerateNum();
    }

    public override string ToString()
    {
        string str = "";
        
        int rows = Nums.GetLength(0);
        int cols = Nums.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                str += $"{Nums[i, j]}\t";
            }
            str += $"\n";
        }

        return str;
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
