using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DM
{
    /// <summary>
    /// 没有运用桥接模式，每增加一个渲染引擎就要在每个图形中去添加对应的渲染引擎与渲染方式,违反了开闭原则
    /// </summary>
    public class NoBrige : MonoBehaviour
    {


        void Start()
        {
            Sphere sphere = new Sphere();
            sphere.DrawInOpenGL();
            Cube cube = new Cube();
            cube.DrawInDrectX();

        }

    }

    //-------------------------各种形状--------------------------
    /// <summary>
    /// 球形
    /// </summary>
    public class Sphere
    {
        public string name = "Sphere";
        public OpenGL openGL = new OpenGL();
        public DrectX drectX = new DrectX();

        public void DrawInOpenGL()
        {
            openGL.Render(name);
        }

        public void DrawInDrectX()
        {
            drectX.Render(name);
        }
    }

    /// <summary>
    /// 方形
    /// </summary>
    public class Cube
    {
        public string name = "Cube";
        public OpenGL openGL = new OpenGL();
        public DrectX drectX = new DrectX();

        public void DrawInOpenGL()
        {
            openGL.Render(name);
        }

        public void DrawInDrectX()
        {
            drectX.Render(name);
        }
    }

    /// <summary>
    /// 柱形
    /// </summary>
    public class Cylinder
    {
        public string name = "Cylinder";
        public OpenGL openGL = new OpenGL();
        public DrectX drectX = new DrectX();

        public void DrawInOpenGL()
        {
            openGL.Render(name);
        }

        public void DrawInDrectX()
        {
            drectX.Render(name);
        }
    }

    //------------------------------------渲染引擎--------------------------------

    public class OpenGL
    {
        public void Render(string name)
        {
            Debug.Log("OpenGL 绘制出了：" + name);
        }
    }

    public class DrectX
    {
        public void Render(string name)
        {
            Debug.Log("DrectX 绘制出了：" + name);
        }
    }
}