using UnityEngine;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //2. 스크립트의 필드 선언부에서 Transform, GameObject 의 객체(인스턴스)를 public 으로 선언한 후 유니티툴의
        //   인스펙터 창에서 직접 오브젝트를 연결하기
        public Transform publicTransform;
        public GameObject publicObject;

        //3. 게임 오브젝트의 tag 를 이용하여 GameObject 의 객체(인스턴스) 가져오기
        private GameObject[] tagObjects; 
        private GameObject tagObject;

        //4. 프리팹 게임 오브젝트 생성 시 Instantiate 함수의 반환값으로 GameObject 의 객체(인스턴스) 가져오기
        public GameObject gameobjectPrefab;

        //5. 같은 종류, 기능들로 묶어서 게임 오브젝트의 객체(인스턴스) 가져오기
        //   부모 게임 오브젝트를 만들어서 묶은 다음 부모 오브젝트에 접근하여 자식 오브젝트들의 객체를 가져온다
        public Transform parentObject;
        private Transform[] childObject;

        //6. static, 싱글톤 패턴 디자인으로 게임 오브젝트들의 객체(인스턴스) 가져오기
        private SingletonTest singletonTest;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //1. 게임 오브젝트에 스크립트 소스를 컴포넌트로 추가하여 직접(this.) 가져오기
            // this.transform, this.gameObject

            //2.
            //publicTransform
            //publicObject

            //3. FindGameObjectsWithTag(), FindGameObjectWithTag() 반환값으로 게임 오브젝트의 객체를 가져온다
            //tagObjects = GameObject.FindGameObjectsWithTag("tagString");
            //tagObject = GameObject.FindGameObjectWithTag("tagString");

            //4. Instantiate(프리팹 오브젝트, 생성 위치, 생성 회전값) 의 반환값으로 게임 오브젝트의 객체를 가져온다
            //GameObject prefabGo = Instantiate(gameobjectPrefab, this.transform.position, Quaternion.identity);

            //5. parentObject.childCount, parentObject.GetChild() 반환값으로 자식 게임 오브젝트들의 객체를 가져온다
            /*childObject = new Transform[parentObject.childCount];
            for (int i = 0; i < childObject.Length; i++)
            {
                childObject[i] = parentObject.GetChild(i);
            }*/

            //6. 싱글톤 패턴 디자인 : 클래스이름.객체이름 으로 접근하여 사용
            //SingletonTest.Instance.number = 10;
            //singletonTest.number = 10;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

/*
(하이라키 창에 있는)게임 오브젝트의 gameobject, transform 에 접근하는 방법
게임 오브젝트의 GameObject, Transform 클래스의 객체를 가져오는 방법

1. 게임 오브젝트에 스크립트 소스를 컴포넌트로 추가하여 직접(this.) 가져오기
2. 스크립트의 필드 선언부에서 Transform, GameObject 의 객체(인스턴스)를 public 으로 선언한 후 유니티툴의
   인스펙터 창에서 직접 오브젝트를 연결하기
3. 게임 오브젝트의 tag 를 이용하여 GameObject 의 객체(인스턴스) 가져오기
4. Instantiate(프리팹 오브젝트, 생성 위치, 생성 회전값) 의 반환값으로 게임 오브젝트의 객체를 가져온다
5. 같은 종류, 기능들로 묶어서 게임 오브젝트의 객체(인스턴스) 가져오기
   부모 게임 오브젝트를 만들어서 묶은 다음 부모 오브젝트에 접근하여 자식 오브젝트들의 객체를 가져온다 
   parentObject.childCount, parentObject.GetChild() 반환값으로 가져오기
6. static : 싱글톤 패턴 디자인을 이용하여 게임 오브젝트 객체(인스턴스) 가져오기
   클래스 이름.인스턴스 이름, 클래스 이름.Instance

*/