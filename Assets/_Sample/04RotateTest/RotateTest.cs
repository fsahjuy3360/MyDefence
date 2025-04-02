using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        // 필드
        private float x;

        // 회전 속도
        public float turnSpeed = 5f;

        // 이동 속도
        public float moveSpeed = 5f;

        // 타겟 오브젝트
        public Transform target;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);   // x축 회전
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);   // y축 회전 
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);   // z축 회전 

        }

        // Update is called once per frame
        void Update()
        {
            // y축 기준으로 + 회전하기
            //x += 1;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);

            //x축 기준으로 + 회전하기
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f);

            //z축 기준으로 + 회전하기
            //this.transform.rotation = Quaternion.Euler(0f, 0f, x);

            //y축 기준으로 속도 5로 회전하기
            //x += Time.deltaTime * 10;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);

            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);

            //타겟 오브젝트 중심으로 회전하기 - 공전
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

            // 타겟 방향으로 회전하기

            //Vector3 dir = 타겟 위치 - 현재 위치
            //Vector3 dir = target.position - this.transform.position;

            //방향 Vector로부터 그 쪽 방향을 바라보는 회전 값 구하기
            //Quaternion targetRotation = Quaternion.LookRotation(dir);

            //Quaternion lookRotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
            //this.transform.rotation = lookRotation;

            // y축 연산을 위해 Euler(오일러)값 얻어오기
            //Vector3 eulerRotation = lookRotation.eulerAngles;

            // Euler(오일러)값으로 Quaternion(쿼터니언)값 구하기
            //this.transform.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);

            // 회전 + 이동

            // 타겟 방향 구하기
            Vector3 dir = target.position - this.transform.position;

            //방향 Vector를 바라보는 회전 값 구하기
            this.transform.rotation = Quaternion.LookRotation(dir);

            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}

/*
Quaternion(쿼터니언)
Euler(오일러)

[1] Euler(오일러)값으로 Quaternion(쿼터니언) 값 구하기
3자리에서 4자리 값 구하기
Quaternion(쿼터니언) 값 -> Quaternion.Euler(Euler x, Euler y, Euler z)

[2] Quaternion(쿼터니언) 값에서 Euler(오일러)값 구하기
4자리에서 3자리 값 구하기
Var angles = Quaternion(transform.rotation).eulerAngles;
*/