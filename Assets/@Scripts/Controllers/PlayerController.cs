using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero; //�÷��̾ ������ ����
    float _speed = 5.0f; //�÷��̾��� �ӵ�
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

    void UpdateInput() //Ű���� �Է��� �޾Ƽ� ������ �ٲ��ִ� �Լ�
    {
    }

    void MovePlayer() //�̵��ϴ� �Լ�
    {
        Vector3 dir = _moveDir * _speed * Time.deltaTime;
        transform.position += dir;
    }
}
