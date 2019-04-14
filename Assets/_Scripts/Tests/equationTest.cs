using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript 
{
    static int arrayLength = 27;
    static int _num = 27;


    //testing the first multidimensional array in the reel.json (ReelStrips[0])
    //if num = 27 reel[0] = 27
    //final result for _num of 27 is {27,0,1,2,3} to prove that we are looping through our images correctly

    [Test]
    public void testEquationOne()//reel[1] = 0
    {
       int addition = 1;
       int result = _num + addition <= arrayLength ? _num + addition : arrayLength - _num - addition < 0 ? ((arrayLength - _num - addition) * -1) - 1 : 0;

       Assert.AreEqual(result, 0);
    }

    [Test]
    public void testEquationTwo()//reel[2] = 1
    {
        int addition = 2;

        int result = _num + addition <= arrayLength ? _num + addition : arrayLength - _num - addition < 0 ? ((arrayLength - _num - addition) * -1) - 1 : 0;
        Assert.AreEqual(result, 1);
    }

    [Test]
    public void testEquationThree()//reel[3] = 2
    {
        int addition = 3;

        int result = _num + addition <= arrayLength ? _num + addition : arrayLength - _num - addition < 0 ? ((arrayLength - _num - addition) * -1) - 1 : 0;
        Assert.AreEqual(result, 2);
    }
    [Test]
    public void testEquationFour()//reel[4] = 3
    {
        int addition = 4;

        int result = _num + addition <= arrayLength ? _num + addition : arrayLength - _num - addition < 0 ? ((arrayLength - _num - addition) * -1) - 1 : 0;
        Assert.AreEqual(result, 3);
    }
}
