using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterChusan : testChusang,TestClass
{
    public override void TestCH()
    {
        
    }
    public override void TestCH2()
    {
        
    }
    public void Test()
    {

    }
    public void Test2()
    {

    }
}
public interface TestClass
{
    public void Test();
    public void Test2();
}
public abstract class testChusang
{
    public abstract void TestCH();
    public abstract void TestCH2();
}
public class MonoTeset : MonoBehaviour
{
    public testChusang testChusang;
    public TestClass testClass;
    private void Start()
    {
        testChusang = new InterChusan();
        testClass = new InterChusan();
    }
}
