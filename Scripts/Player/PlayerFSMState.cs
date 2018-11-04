using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSMState : MonoBehaviour {

    public FSMManager manager;

    public virtual void BeginState() //virtual 자식에 함수 설정 가능??이라고 했던가...으므...
    {

    }

    private void Awake()
    {
        manager = GetComponent<FSMManager>();
    }
}
