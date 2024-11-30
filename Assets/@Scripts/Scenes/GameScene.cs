using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameScene : MonoBehaviour
{


    GameObject _slime;
    GameObject _snake;
    GameObject _goblin;
    GameObject _joystick;
    void Start()
    {
        Managers.Resource.LoadAAllAsync<GameObject>("Prefabs", (key, count, totalCount) => //�񵿱� �ε� ����
        {
            Debug.Log($" {key} : {count}/{totalCount}");

            if(count == totalCount) //�ε尡 ������
            {
                StartLoaded(); 
            }
        });

        
        
    }

    void StartLoaded() //�ε尡 �� ���� ���� �ؾ��� �ϵ�
    {
        GameObject prefab = Managers.Resource.Load<GameObject>("Slime_01.prefab");

        GameObject go = new GameObject() { name = "@Monsters" };

        _snake.transform.parent = go.transform;
        _goblin.transform.parent = go.transform;

        //_slime.name = _slimePrefab.name;
        //_snake.name = _snakePrefab.name;
        //_goblin.name = _goblinPrefab.name;

        _slime.AddComponent<PlayerController>();

        Camera.main.GetComponent<CameraController>().Target = _slime; //���� ī�޶� ã�Ƽ� ����� ���������� ����

        _joystick.name = "@UI_Joystick";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
