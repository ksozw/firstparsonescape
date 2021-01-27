using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : GimmickBase
{
    Animator m_animator;
    
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    public override void Action()
    {
        Debug.Log("エレベーターが動く");
        m_animator.Play("MoveElevator");
        //Camera.main.transform.LookAt(this.transform);
    }
}
