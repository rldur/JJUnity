using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLE : PlayerFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.CrossFade("KK_Idle");
        //getcomponent >> 오브젝트 안에 있는 컴포넌트를 불러옴, GetcomponentInChildren>> 자식에 있는 컴포넌트를 불러옴.
    }

    // Update is called once per frame
    void Update ()
    {
        
	}
}
