﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Run");
    }
    
    void Update ()
    {
        GameLib.JJMove(manager.cc, manager.target, manager.stat);
        
        Vector3 diff = manager.target.position - transform.position;
        diff.y = 0.0f;

        if (diff.magnitude < manager.stat.attackRange)
        {
            manager.SetState(PlayerState.ATTACK);
        }
    }
}
