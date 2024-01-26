using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepShoot : MonoBehaviour
{
    RotateAroundPivot rotateAroundPivot;

    private void Start()
    {
        rotateAroundPivot = GameObject.Find("Player1").GetComponentInChildren<RotateAroundPivot>();
    }

    public void OnSweepShoot()
    {
        rotateAroundPivot.sweepShoot = true;
        rotateAroundPivot.SweepShoot();
    }
}
