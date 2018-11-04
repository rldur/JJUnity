using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Run_No");
        // > 업데이트문에 애니메이션 = 부하가 심함. 그래서!
    }
    void Update()
    {
        GameLib.JJMove(manager.cc, manager.marker, manager.stat);

        //if (Vector3.Distance(transform.position, manager.marker.position) < 0.1f)
        Vector3 diff = manager.marker.position - transform.position;
        diff.y = 0.0f;

        if(diff.magnitude < 0.1f)
        {
            manager.SetState(PlayerState.IDLE);
        }
	}
}
