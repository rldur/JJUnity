using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK
}

public class FSMManager : MonoBehaviour {

    public PlayerState currentState;
    public PlayerState startState;
    public Transform marker;
    public Transform target;
    public Animation anim;
    public CharacterStat stat;
    public CharacterController cc;
    public int layerMask;

    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();

    private void Awake()
    {
        //layerMask = 1 << LayerMask.NameToLayer("Level");
        //layerMask += 1 << LayerMask.NameToLayer("Monster");
        layerMask = (1 << 9) + (1 << 10);
        marker = GameObject.FindGameObjectWithTag("Marker").transform;
        anim = GetComponentInChildren<Animation>();
        stat = GetComponent<CharacterStat>();
        cc = GetComponent<CharacterController>();

        states.Add(PlayerState.IDLE, GetComponent<PlayerIDLE>());
        states.Add(PlayerState.RUN, GetComponent<PlayerRUN>());
        states.Add(PlayerState.CHASE, GetComponent<PlayerCHASE>());
        states.Add(PlayerState.ATTACK, GetComponent<PlayerATTACK>());

        //states[startState].enabled = true; //enabled = true (활성화) false(비활성화)
    }

    public void SetState(PlayerState newState)
    {
        foreach(PlayerFSMState fsm in states.Values) // for문의 개량형, Values의 값을 모두 다 돌림, 기획 변경시 유용.
        {
            fsm.enabled = false;
        }

        states[newState].enabled = true;
        states[newState].BeginState();
    }
    
    void Start ()
    {
        SetState(startState);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0)) //buttonDown 누를때 buttonUp 뗄때 button 누르고 있을때
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r, out hit, 1000, layerMask))
            {
                if (hit.transform.gameObject.layer == 9)
                {
                    marker.position = hit.point;
                    target = null;
                    SetState(PlayerState.RUN);
                }
                else if (hit.transform.gameObject.layer == 10)
                {
                    target = hit.transform;
                    SetState(PlayerState.CHASE);
                }
            }
        }
	}
}
