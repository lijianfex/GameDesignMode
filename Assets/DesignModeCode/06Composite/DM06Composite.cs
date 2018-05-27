using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 组合模式（管理父子物体）
/// </summary>
public class DM06Composite : MonoBehaviour {

	void Start ()
    {
        DMComposite compositeRoot = new DMComposite("CompositeRoot");
        DMLeaf leaf1 = new DMLeaf("Leaf1");
        DMComposite composite = new DMComposite("Composite");
        DMLeaf leaf2 = new DMLeaf("Leaf2");

        compositeRoot.AddChild(leaf1);
        compositeRoot.AddChild(composite);
        compositeRoot.AddChild(leaf2);

        DMLeaf leaf2_1 = new DMLeaf("Leaf2-1");
        DMLeaf leaf2_2 = new DMLeaf("Leaf2-2");

        composite.AddChild(leaf2_1);
        composite.AddChild(leaf2_2);

        DeepReadComposite(compositeRoot); //遍历
	}
	
    //深度遍历
    private void DeepReadComposite(DMCompment compment)
    {
        Debug.Log(compment.Name);
        List<DMCompment> child = compment.Children;
        if (child == null || child.Count == 0) return;
        foreach(DMCompment c in child)
        {
            DeepReadComposite(c);
        }
    }

}

/// <summary>
/// 基类
/// </summary>
public abstract class DMCompment
{
    protected string mName; //组件名
    public string Name { get { return mName; } }

    protected List<DMCompment> mChildren;
    public List<DMCompment> Children { get { return mChildren; } }

    public DMCompment(string name)
    {
        mName = name;
        mChildren = new List<DMCompment>();
    }

    public abstract void AddChild(DMCompment c);
    public abstract void RemoveChild(DMCompment c);

    public abstract DMCompment GetChild(int index);
   
}

/// <summary>
/// 叶节点(无法添加子节点)
/// </summary>
public class DMLeaf : DMCompment
{
    public DMLeaf(string name) : base(name)
    {
    }

    public override void AddChild(DMCompment c)
    {
        return;
    }
    

    public override void RemoveChild(DMCompment c)
    {
        return;
    }
    public override DMCompment GetChild(int index)
    {
        return null;
    }
}


public class DMComposite : DMCompment
{
    public DMComposite(string name) : base(name)
    {
    }

    public override void AddChild(DMCompment c)
    {
        mChildren.Add(c);
    }
    public override void RemoveChild(DMCompment c)
    {
        mChildren.Remove(c);
    }
    public override DMCompment GetChild(int index)
    {
        return mChildren[index];
    }
}

