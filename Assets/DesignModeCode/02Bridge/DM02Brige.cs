using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 桥接模式原型  针对对象会增加的需求
/// </summary>
public class DM02Brige : MonoBehaviour {
   
	void Start()
    {
        DrawCall drawCall = new DrawCall(new Sphere("球形"), new OpenGL());
        drawCall.StartDraw();
        drawCall.StopDraw();
	}
}

/// <summary>
/// 桥接类
/// </summary>
public class DrawCall
{
    public IObject renderObject;

    public IRenderEngine renderEngine;
    public DrawCall(IObject iObject, IRenderEngine iRenderEngine)
    {
        renderObject = iObject;
        renderEngine = iRenderEngine;
    }

    public void StartDraw()
    {
        renderEngine.Render(renderObject);
    }

    public void StopDraw()
    {
        renderEngine.StopRender(renderObject);
    }
}



/// <summary>
/// 所有图形的公共基类
/// </summary>
public class IObject
{
    public string mName;//图形名

    public IObject(string name)
    {
        mName = name;
    }

}



/// <summary>
/// 球形
/// </summary>
public class Sphere:IObject
{
    public Sphere(string str):base(str)
    {

    }
}
/// <summary>
/// 方形
/// </summary>
public class Cube:IObject
{
    public Cube(string str):base(str)
    {

    }
}
/// <summary>
/// 柱形
/// </summary>
public class Cylinder : IObject
{
    public Cylinder(string str) : base(str)
    {

    }
}


/// <summary>
/// 所有渲染引擎的基类
/// </summary>
public abstract class IRenderEngine
{
    public abstract void Render(IObject iobject);//渲染
    public abstract void StopRender(IObject iobject);//停止渲染
}

/// <summary>
/// OpenGL
/// </summary>
public class OpenGL : IRenderEngine
{
    public override void Render(IObject iobject)
    {
        Debug.Log("OpenGL 绘制出：" + iobject.mName);
    }

    public override void StopRender(IObject iobject)
    {
        Debug.Log("OpenGL 停止绘制：" + iobject.mName);
    }
}

/// <summary>
/// DirectX
/// </summary>
public class DirectX : IRenderEngine
{
    public override void Render(IObject iobject)
    {
        Debug.Log("DirectX 绘制出：" + iobject.mName);
    }

    public override void StopRender(IObject iobject)
    {
        Debug.Log("DirectX 停止绘制：" + iobject.mName);
    }
}