// Name : Hoang Nguyen
// Email : Hnguyen1193@csu.fullerton.edu
// Application : 
using System;
using System.Windows.Forms;

public class CollideBall
{
    public static void Main()
    {
        System.Console.WriteLine("Welcome to the main method of the Collide Ball Program");
        CollideBallFrame newapp = new CollideBallFrame();
        Application.Run(newapp);
        System.Console.WriteLine("Main Method will now ShutDown");
    }
}