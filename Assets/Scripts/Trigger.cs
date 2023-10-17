using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Obstacle"))
        {
            GameManager.UpdateScore(1);
        }
    }
}
