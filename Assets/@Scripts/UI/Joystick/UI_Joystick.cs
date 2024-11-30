using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
//화면 터치용 인터페이스들
public class UI_Joystick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    Image _background;

    [SerializeField]
    Image _handler;

    Vector2 _touchPosition; //누른 곳을 기억하는 변수
    float _joystickRadius;

    Vector2 _moveDir;//이동할 방향


    void Start()
    {
        _joystickRadius = _background.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        //조이스틱 BG의 반지름
    }


    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchDir = (eventData.position - _touchPosition); //핸들이 이동할 벡터

        float moveDist = Mathf.Min(touchDir.magnitude, _joystickRadius); //두개의 값을 비교해서 가장 작은값 반환
        _moveDir = touchDir.normalized;

        Vector2 newPosition = _touchPosition + _moveDir * moveDist;
        _handler.transform.position = newPosition;

        Managers.Game.MoveDir = _moveDir; //움직일 방향을 Managers안에 있는 공용 전역 변수 MoveDir에 대입
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _background.transform.position = eventData.position; 
        _handler.transform.position = eventData.position;
        _touchPosition = eventData.position; //내가 누른 곳 기억하기
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _handler.transform.position = _touchPosition; //클릭을 떼면 핸들러 원위치
        _moveDir = Vector2.zero;

        Managers.Game.MoveDir = _moveDir;
    }


}
