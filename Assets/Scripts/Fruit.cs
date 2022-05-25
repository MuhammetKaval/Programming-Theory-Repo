using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Object
{
    public override void CheckBottomBoundary()
    {
        GameOver();
        base.CheckBottomBoundary();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
