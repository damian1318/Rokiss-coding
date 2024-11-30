using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    Vector2 _moveDir; //플레이어의 전역 이동방향

    public event Action<Vector2> OnMoveDirChanged; //액션함수(이동방향 변경)
    //Action<인자> 함수명 ::: Action에 넣어줄 함수는 항상 void
    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value; //값을 설정해주고
            OnMoveDirChanged?.Invoke(_moveDir); //액션을 호출해서 인자로 _moveDir을 전달
        }
    }
}
