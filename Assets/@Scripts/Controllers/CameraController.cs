using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target; //ī�޶� ����ٴ� ���

    void Start()
    {
    }

    //LateUpdate�� ���� : 
    //���߰��� �ſ� ���� ������Ʈ���� ������Ʈ �� �ٵ�
    //�߰��� ī�޶� ������Ʈ �ع����� �̻������� �߻��ϱ⿡ 
    //ī�޶�� ���� �ļ����� LateUpdate�� �����صд�
    void LateUpdate()
    {
        if (Target == null)
            return;

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);
    }
}
