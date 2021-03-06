﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI 工具类
/// </summary>
public static class UITool
{ 
    /// <summary>
    /// 得到Canvas
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject GetCanvas(string name="Canvas")
    {
        return GameObject.Find(name);
    }

    
    /// <summary>
    /// 得到某物体组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
    public static T FindChild<T>(GameObject parent , string childName) where T:Component
    {
        GameObject uiGO = UnityTool.FindChild(parent, childName);
        if(uiGO==null)
        {
            Debug.LogError("在游戏物体下" + parent + "查找不到" + childName);
            return default(T);
        }
        return uiGO.GetComponent<T>();
    }
}