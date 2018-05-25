using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用工具类
/// </summary>
public static class UnityTool
{
    /// <summary>
    /// 查找子物体
    /// </summary>
    /// <typeparam name="T">组件</typeparam>
    /// <param name="root">根物体</param>
    /// <param name="childName">子物名</param>
    /// <returns></returns>
    public static GameObject FindChild<T>(GameObject rootParent , string childName) where T:Component
    {
        T[] childrens = rootParent.GetComponentsInChildren<T>();
        bool isFind = false;
        T child = null;
        foreach(T t in childrens)
        {
            if(t.name==childName)
            {
                if (isFind == true)
                {
                    Debug.LogWarning("游戏物体：{" + rootParent.name + "}下，存在多个子物体：" + childName);
                    continue;
                }
                isFind = true;
                child = t;                
            }
        }
        return child.gameObject;
    }

    /// <summary>
    /// 挂载子物体
    /// </summary>
    /// <param name="anchorParent">挂载点</param>
    /// <param name="child">子物体</param>
    public static void AttachChild(GameObject anchorParent,GameObject child)
    {
        child.transform.SetParent(anchorParent.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localEulerAngles = Vector3.zero;
    }
	
}
