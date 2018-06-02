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
    
    public static GameObject FindChild(GameObject rootParent , string childName)
    { 
        Transform[] childrens = rootParent.GetComponentsInChildren<Transform>();
        bool isFind = false;
        Transform child = null;
        foreach(Transform t in childrens)
        {
            if(t.name==childName)
            {
                if (isFind)
                {
                    Debug.LogWarning("游戏物体：{" + rootParent.name + "}下，存在多个子物体：" + childName); 
                }
                isFind = true;
                child = t;                
            }
        }
        if(isFind)
        {
            return child.gameObject;
        }
        return null;
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
