using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM05Builder : MonoBehaviour
{
    private void Start()
    {
        IBuilder fatBuilder = new FatPresonBuilder();
        //IBuilder thinBuilder = new ThinPersonBuilder();

        Person fatPerson = Directer.Construct(fatBuilder);
        fatPerson.Show();
        
    }
}

class Person
{
    private List<string> parts = new List<string>();

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        foreach (string s in parts)
        {
            Debug.Log(s);
        }
    }
}

class FatPerson : Person { }
class ThinPerson : Person { }

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFeet();
    Person GetResult();
}

class FatPresonBuilder : IBuilder
{
    private Person person;

    public FatPresonBuilder()
    {
        person = new FatPerson();
    }


    public void AddBody()
    {
        person.AddPart("胖人身");
    }

    public void AddFeet()
    {
        person.AddPart("胖人脚");

    }

    public void AddHand()
    {
        person.AddPart("胖人手");
    }

    public void AddHead()
    {
        person.AddPart("胖人头");

    }

    public Person GetResult()
    {
        return person;
    }
}

class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new ThinPerson();
    }

    public void AddBody()
    {
        person.AddPart("瘦人身");
    }

    public void AddFeet()
    {
        person.AddPart("瘦人脚");

    }

    public void AddHand()
    {
        person.AddPart("瘦人手");
    }

    public void AddHead()
    {
        person.AddPart("瘦人头");

    }

    public Person GetResult()
    {
        return person;
    }
}

class Directer
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddFeet();
        builder.AddHand();
        builder.AddHead();
        return builder.GetResult();          
    }
}