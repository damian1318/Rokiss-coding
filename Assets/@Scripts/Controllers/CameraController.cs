using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target; //카메라가 따라다닐 대상

    void Start()
    {
    }

    //LateUpdate인 이유 : 
    //나중가면 매우 많은 오브젝트들이 업데이트 할 텐데
    //중간에 카메라가 업데이트 해버리면 이상현상이 발생하기에 
    //카메라는 제일 후순위인 LateUpdate로 설정해둔다
    void LateUpdate()
    {
        if (Target == null)
            return;

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);
    }
}
