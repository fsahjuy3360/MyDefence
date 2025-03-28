using UnityEngine;

namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        // 필드
        #region Field
        private float speed = 10f;
        private Vector3 targetPosition;
        private int wayPointIndex = 0;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 초기화
            wayPointIndex = 0;
            targetPosition = WayPoints.wayPoints[wayPointIndex].position;
        }

        // Update is called once per frame
        void Update()
        {
            // 이동 구현
            Vector3 dir = targetPosition - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

            // targetPosition 판정
            float distance = Vector3.Distance(targetPosition, this.transform.position);

            
            if (distance <= 0.1f)
            {
                
                GetNextTargetPosition();
                
            }



        }
        // 다음 타겟포지션을 얻어오기 
        void GetNextTargetPosition()
        {
            wayPointIndex++;
            if (wayPointIndex == 8)
            {
                //Debug.Log("종점 도착");
                Destroy(this.gameObject);
                return;
            }
            
            //Debug.Log($"wayPointIndex: {wayPointIndex}");
            targetPosition = WayPoints.wayPoints[wayPointIndex].position;
        }
    }

}