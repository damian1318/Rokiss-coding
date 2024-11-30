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
        Managers.Resource.LoadAAllAsync<GameObject>("Prefabs", (key, count, totalCount) => //비동기 로드 시작
        {
            Debug.Log($" {key} : {count}/{totalCount}");

            if(count == totalCount) //로드가 끝나면
            {
                StartLoaded(); 
            }
        });

        
        
    }

    void StartLoaded() //로드가 다 끝난 다음 해야할 일들
    {
        GameObject prefab = Managers.Resource.Load<GameObject>("Slime_01.prefab");

        GameObject go = new GameObject() { name = "@Monsters" };

        _snake.transform.parent = go.transform;
        _goblin.transform.parent = go.transform;

        //_slime.name = _slimePrefab.name;
        //_snake.name = _snakePrefab.name;
        //_goblin.name = _goblinPrefab.name;

        _slime.AddComponent<PlayerController>();

        Camera.main.GetComponent<CameraController>().Target = _slime; //메인 카메라를 찾아서 대상을 슬라임으로 지정

        _joystick.name = "@UI_Joystick";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
