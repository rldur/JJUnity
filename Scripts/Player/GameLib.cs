using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class GameLib
{
    public static void JJMove(CharacterController cc, Transform target, CharacterStat stat)
    {
        Transform transform = cc.transform;

        //Quaternion.RotateTowards >> 부드러운 회전!
        //B-A는 A에서 B로 향하는 벡터.
        Vector3 dir = target.position - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), stat.turnSpeed * Time.deltaTime);
        }

        //transform.position = marker.position (순간이동)
        //transform.position = Vector3.MoveTowards(transform.position, manager.marker.position, manager.stat.moveSpeed * Time.deltaTime);
        //이건 물리가 들어가지 않아서 망함

        Vector3 deltaMove = Vector3.MoveTowards(transform.position, target.position, stat.moveSpeed * Time.deltaTime) - transform.position;
        deltaMove.y = -stat.fallSpeed * Time.deltaTime;
        cc.Move(deltaMove);
    }
}