using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 计时销毁组件
/// </summary>
public class DestroyForTime : MonoBehaviour
{
    public float time = 1.0f;

    void Start()
    {
        Invoke("Destroy", time);        
    }

    private void Destroy()
    {
        DestroyImmediate(this.gameObject);
    }
}