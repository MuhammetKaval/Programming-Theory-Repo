using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Bomb : Object
{
    // POLYMORPHISM
    public override void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
        {
            GameOver(); // ABSTRACTION
            base.OnMouseDown();
        }
    }

    public void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
