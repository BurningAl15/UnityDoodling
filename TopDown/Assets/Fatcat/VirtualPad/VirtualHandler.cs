using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualHandler : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler{
    Image Container;
    Image joystick;
    public Vector3 inputDirection;
    static bool isTouched;
	// Use this for initialization
	void Start () {
        Container = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        inputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(Container.rectTransform,
            ped.position, ped.pressEventCamera, out position))
        {
            //isTouched = true;
            position.x = (position.x / Container.rectTransform.sizeDelta.x);
            position.y = (position.y / Container.rectTransform.sizeDelta.y);

            float x = (Container.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (Container.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            inputDirection = new Vector3(x, y, 0);
            inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

            //to define the area in which joystick can move around
            joystick.rectTransform.anchoredPosition = new Vector3(inputDirection.x * (Container.rectTransform.sizeDelta.x *0.4f)
                                                                   , inputDirection.y * (Container.rectTransform.sizeDelta.y) * 0.4f);


        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        isTouched = true;
        Container.color = new Vector4(Container.color.r, Container.color.g, Container.color.b, 0.5f);
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        Container.color = new Vector4(Container.color.r, Container.color.g, Container.color.b, 1f);
        isTouched = false;
    }

    public float Horizontal()
    {
        if(inputDirection.x!=0)
        {
            return inputDirection.x;
        }
        return Input.GetAxisRaw("Horizontal");
    }

    public float Vertical()
    {
        if (inputDirection.y != 0)
        {
            return inputDirection.y;
        }
        return Input.GetAxisRaw("Vertical");
    }

    public static bool IsTouched()
    {
        return isTouched;
    }
}
