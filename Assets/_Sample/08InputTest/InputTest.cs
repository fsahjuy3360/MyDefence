using UnityEngine;
using TMPro;
namespace Sample
{
     // Old InputSystem
    public class InputTest : MonoBehaviour
    {
        //UI Text
        public TextMeshProUGUI xText;
        public TextMeshProUGUI yText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // GetKey(키값)
            /* if (Input.GetKey("w"))
             {
                 Debug.Log("w키를 누르고 있습니다");
             }

             if (Input.GetKeyDown(KeyCode.W))
             {
                 Debug.Log("w키를 눌렀습니다");
             }

             if (Input.GetKeyUp(KeyCode.W))
             {
                 Debug.Log("w키를 눌렀다가 떼었습니다");
             }*/

            // GetButton(버튼이름) - InputManager
            /*if (Input.GetButton("Jump"))
            {
                Debug.Log("점프 버튼을 누르고 있습니다");
            }

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 버튼을 눌렀습니다");
            }

            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프 버튼을 눌렀다가 떼었습니다");
            }
            */

            // GetAxis(Axis 이름) - InputManager

            //float hValue = Input.GetAxis("Horizontal");
            //Debug.Log($"Horizontal 값: {hValue}");
            // a나 left : -1 ~ 0
            // d나 right : 0 ~ 1

            //float hValue = Input.GetAxisRaw("Horizontal");
            //Debug.Log($"Horizontal 값: {hValue}");
            // a나 left : -1, 0
            // d나 right : 0, 1

            //float vValue = Input.GetAxis("Vertical");
            //Debug.Log($"Vertical 값: {vValue}");
            // s나 down : -1 ~ 0
            // w나 up : 0 ~ 1

            //float vValue = Input.GetAxisRaw("Vertical");
            //Debug.Log($"Vertical 값: {vValue}");
            // s나 down : -1, 0
            // w나 up : 0, 1

            // 마우스 포인터의 스크린 위치값 얻어오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            xText.text = "MouseX" + ((int)mouseX).ToString() + ((int)mouseY).ToString();
            //yText.text = "MouseY" + ((int)mouseY).ToString();
            xText.rectTransform.position = new Vector2(mouseX, mouseY);

        }
    }
}
/*
Old InputSystem


New InputSystem
*/