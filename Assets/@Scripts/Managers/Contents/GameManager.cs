using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    Vector2 _moveDir; //�÷��̾��� ���� �̵�����

    public event Action<Vector2> OnMoveDirChanged; //�׼��Լ�(�̵����� ����)
    //Action<����> �Լ��� ::: Action�� �־��� �Լ��� �׻� void
    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value; //���� �������ְ�
            OnMoveDirChanged?.Invoke(_moveDir); //�׼��� ȣ���ؼ� ���ڷ� _moveDir�� ����
        }
    }
}
