using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero; //플레이어가 움직일 방향
    float _speed = 5.0f; //플레이어의 속도
    void Start()
    {
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
    }
    void OnDestroy()
    {
        if(Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
    }

    void HandleOnMoveDirChanged(Vector2 dir)
    {
        _moveDir = dir;
    }


    void Update()
    {
        //UpdateInput();

        MovePlayer();
    }

    void UpdateInput() //키보드 입력을 받아서 방향을 바꿔주는 함수
    {
    }

    void MovePlayer() //이동하는 함수
    {
        Vector3 dir = _moveDir * _speed * Time.deltaTime;
        transform.position += dir;
    }
}
