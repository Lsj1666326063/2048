using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera2DAdaptive : MonoBehaviour
{
    public enum AdaptiveModel
    {
        Width,
        Height
    }
    
    public Vector2Int designResolution = new Vector2Int(1920,1080);

    public AdaptiveModel adaptiveModel;

    private Vector2Int curResolution;
    
    private Camera mCamera;
    
    private void Awake()
    {
        curResolution = new Vector2Int(Screen.width, Screen.height);
        
        mCamera = GetComponent<Camera>();
        mCamera.orthographic = true;
        
        Adaptive();
    }

    private void LateUpdate()
    {
        if (curResolution.x != Screen.width || curResolution.y != Screen.height)
        {
            curResolution.x = Screen.width;
            curResolution.y = Screen.height;
            Adaptive();
        }
    }

    // 一般

    private void Adaptive()
    {
        switch (adaptiveModel)
        {
            case AdaptiveModel.Width:
                AdaptiveWidth();
                break;
            case AdaptiveModel.Height:
                AdaptiveHeight();
                break;
            default:
                break;
        }
    }

    private void AdaptiveHeight()
    {
        float orthographicSize = (float)designResolution.y / 100 / 2;
        SetOrthographicSize(orthographicSize);
    }

    private void AdaptiveWidth()
    {
        int screenGcd = Gcd(Screen.width, Screen.height);
        float num = designResolution.x / ((float)Screen.width/screenGcd);
        num *= ((float) Screen.height / screenGcd);
        float orthographicSize = num / 100 / 2;
        SetOrthographicSize(orthographicSize);
    }

    private void SetOrthographicSize(float orthographicSize)
    {
        mCamera.orthographicSize = orthographicSize;
    }
    
    private int Gcd(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }
        if (a == 0)
            return b;
        else
            return a;
    }
}
