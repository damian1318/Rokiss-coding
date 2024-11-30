using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
//ȭ�� ��ġ�� �������̽���
public class UI_Joystick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    Image _background;

    [SerializeField]
    Image _handler;

    Vector2 _touchPosition; //���� ���� ����ϴ� ����
    float _joystickRadius;

    Vector2 _moveDir;//�̵��� ����


    void Start()
    {
        _joystickRadius = _background.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        //���̽�ƽ BG�� ������
    }


    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchDir = (eventData.position - _touchPosition); //�ڵ��� �̵��� ����

        float moveDist = Mathf.Min(touchDir.magnitude, _joystickRadius); //�ΰ��� ���� ���ؼ� ���� ������ ��ȯ
        _moveDir = touchDir.normalized;

        Vector2 newPosition = _touchPosition + _moveDir * moveDist;
        _handler.transform.position = newPosition;

        Managers.Game.MoveDir = _moveDir; //������ ������ Managers�ȿ� �ִ� ���� ���� ���� MoveDir�� ����
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _background.transform.position = eventData.position; 
        _handler.transform.position = eventData.position;
        _touchPosition = eventData.position; //���� ���� �� ����ϱ�
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _handler.transform.position = _touchPosition; //Ŭ���� ���� �ڵ鷯 ����ġ
        _moveDir = Vector2.zero;

        Managers.Game.MoveDir = _moveDir;
    }


}
