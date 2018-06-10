using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 访问模式
/// </summary>
public class DM11Visitor : MonoBehaviour
{
    private void Start()
    {
        DMShpere shpere1 = new DMShpere();
        DMShpere shpere2= new DMShpere();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();
        DMCube cube3 = new DMCube();
        DMCylinder cylinder1 = new DMCylinder();

        DMShapeContainer container = new DMShapeContainer();
        container.AddShape(shpere1);
        container.AddShape(shpere2);
        container.AddShape(cube1);
        container.AddShape(cube2);
        container.AddShape(cube3);
        container.AddShape(cylinder1);

        AccountOfShapeVisitor shapeVisitor = new AccountOfShapeVisitor();
        container.RunVisitor(shapeVisitor);
        Debug.Log("图形数量：" + shapeVisitor.account);

        AccountOfCubeVisitor cubeVisitor = new AccountOfCubeVisitor();
        container.RunVisitor(cubeVisitor);
        Debug.Log("Cube数量：" + cubeVisitor.account);



    }



}

class DMShapeContainer
{
    private List<IDMShape> mShpaes = new List<IDMShape>();

    public void AddShape(IDMShape shape)
    {
        mShpaes.Add(shape);
    }

    /// <summary>
    /// 运行访问者
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(IShapeVisitor visitor)
    {
        foreach(IDMShape shape in mShpaes )
        {
            shape.RunVisitor(visitor);
        }
    }
}

abstract class IDMShape
{
    public abstract void RunVisitor(IShapeVisitor visitor);
}

class DMShpere : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

class DMCylinder : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}

class DMCube : IDMShape
{
    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

/// <summary>
/// 基类访问者
/// </summary>
abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMShpere shpere);
    public abstract void VisitCylinder(DMCylinder cylinder);
    public abstract void VisitCube(DMCube cube);
}


/// <summary>
/// 统计图形总数得访问者
/// </summary>
class AccountOfShapeVisitor : IShapeVisitor
{
    public int account=0;

    public override void VisitCube(DMCube cube)
    {
        account++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        account++;
    }

    public override void VisitSphere(DMShpere shpere)
    {
        account++;
    }
}

/// <summary>
/// 统计Cube的数量的访问者
/// </summary>
class AccountOfCubeVisitor : IShapeVisitor
{
    public int account;
     
    public override void VisitCube(DMCube cube)
    {
        account++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMShpere shpere)
    {
        return;
    }
}


