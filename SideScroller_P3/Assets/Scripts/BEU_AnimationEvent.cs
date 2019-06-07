using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_AnimationEvent : MonoBehaviour
{
    public GameObject hitPoint;

    public void enablehitPoint()
    {
        hitPoint.SetActive(true);
    }

    public void disableHitPoint()
    {
        hitPoint.SetActive(false);
    }
}
