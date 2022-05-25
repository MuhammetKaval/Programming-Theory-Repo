using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Fruit : Object
{
    [SerializeField] private int scorePoint;

    // POLYMORPHISM
    public override void CheckBottomBoundary()
    {
        if (GameManager.Instance.isGameActive)
        {
            GameOver(); // ABSTRACTION
            base.CheckBottomBoundary();
        }
    }

    // POLYMORPHISM
    public override void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
        {
            GameManager.Instance.UpdateScore(scorePoint);
            base.OnMouseDown();
        }
    }

    public void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}