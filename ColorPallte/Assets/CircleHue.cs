using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircleHue : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Center;
    public GameObject StartPos;

    [SerializeField] bool isMouse;

    Vector3 clickPos;

    float mouseX;

    float theta = 0;
    float distance = 0;

    bool flag = false;

    public Slider slider_;

    float value_;

    // Use this for initialization
    void Start()
    {
        Handle.transform.position = StartPos.transform.position;
        //print("handle pos : " + Handle.transform.position);
        distance = Vector2.Distance(StartPos.transform.position, Center.transform.position);

        //print(distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            float distance = Vector2.Distance(Handle.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            //Debug.Log(Handle.transform.position);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Debug.Log(Input.mousePosition);

            //Debug.Log("distance : " + distance);

            if (distance < 1)
            {

            }
            else if (distance >= 1)
            {
                flag = false;
            }
            //Debug.Log(distance);
        }
    }

    void FixedUpdate()
    {
        // 만약 클릭이 되었다면.
        if (flag == true)
        {
            CircleHueClicked();
        }
    }


    public void CirlceHuePointerDown()
    {
        flag = true;
    }

    public void CircleHuePointerUp()
    {
        flag = false;
    }


    public void CircleHueClicked()
    {
        var touches = Input.touches;
        int touchesCount = touches.Length;
        float minDist = float.MaxValue;
        Vector3 closePoint = Vector3.zero;

        if (isMouse)
        {
            float dist = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), Input.mousePosition);
            if (minDist > dist)
            {
                minDist = dist;
                closePoint = Input.mousePosition;
            }
            if (closePoint.magnitude == 0) return;
        }
        else
        {
            for (int i = 0; i < touchesCount; i++)
            {
                float dist = Vector3.Distance(Camera.main.WorldToScreenPoint(transform.position), touches[i].position);
                if (minDist > dist)
                {
                    minDist = dist;
                    closePoint = touches[i].position;
                }
            }
            if (closePoint.magnitude == 0) return;
        }


        clickPos = Camera.main.ScreenToWorldPoint(closePoint);

        theta = 0.0f;
        Vector3 dir = (clickPos - Center.transform.position).normalized;
        Vector3 realClickPos = Center.transform.position + dir * distance;
        theta = Mathf.PI / 2 - Mathf.Atan2(realClickPos.y - Center.transform.position.y, realClickPos.x - Center.transform.position.x);// * 180.0f / Mathf.PI;

        Handle.transform.position = Center.transform.position + new Vector3(distance * Mathf.Sin(theta), distance * Mathf.Cos(theta));

        if (0 > theta * Mathf.Rad2Deg)
        {
            value_ = (360.0f + (theta * Mathf.Rad2Deg)) / 360.0f;
        }
        else
        {
            value_ = theta * Mathf.Rad2Deg / 360.0f;
        }

        slider_.value = value_;
    }
}
