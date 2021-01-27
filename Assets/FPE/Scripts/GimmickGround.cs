using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickGround : GimmickBase
{
    public void Start()
    {
        this.gameObject.SetActive(false);
    }
    public override void Action()
    {
        Debug.Log("足場が現れる");
        this.gameObject.SetActive(true);
    }
}
