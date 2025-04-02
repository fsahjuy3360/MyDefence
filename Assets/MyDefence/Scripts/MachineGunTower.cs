using UnityEngine;

namespace MyDefence
{
    //  MachineGunTower를 관리하는 클래스
    public class MachineGunTower : MonoBehaviour
    {
        #region Field
        // 공격 범위
        public float attackRange = 7f;

        // 가장 가까운 적
        private Transform target;

        // Enemy tag
        public string enemyTag = "Enemy";

        // search 타이머
        public float searthTimer = 0.5f;
        //private float countDown = 0f;

        // 터렛 헤드 회전
        public Transform partToRotate;
        public float turnSpeed = 5;

        // shoot 타이머
        public float shootTimer = 1f;
        private float shootCountDown = 0f;

        // Bullet 발사
        public GameObject bulletPrefab;
        public Transform firePoint;
        


        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // UpdateTarget 함수를 즉시 0.5초 마다 반복해서 호출한다
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            // 가장 가까운 적 찾기

            /* countDown += Time.deltaTime;
             if (countDown >= searthTimer)
             {
                 // 타이머 기능 함수 호출
                 UpdateTarget();

                 // 타이머 초기화
                 countDown = 0f;
             }*/

            // 터렛 헤드 회전

            if (target == null)

                return;

            // 타겟 조준
            LockOn();

            // 타겟팅이 되면 터렛이 1초마다 1발 씩 쏘기
            // Debug.Log("Shoot!!!");


            shootCountDown += Time.deltaTime;
            if (shootCountDown >= shootTimer)
            {
                Shoot();

                shootCountDown = 0f;
            }


        }

        private void Shoot()
        {
            //Debug.Log("Shoot!!!");
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target);
            }
            

        }


        //타겟 조준
        void LockOn()
        {
            Vector3 dir = target.position - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Quaternion lookRotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, Time.deltaTime * turnSpeed);
            Vector3 eulerRotation = lookRotation.eulerAngles;   // 4자리에서 3자리 구하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }

        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            // 최소 거리 일때의 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;

            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            
            if (nearEnemy != null && minDistance <= attackRange )
            {
                target = nearEnemy.transform;
                
            }
            else
            {
                target = null;
            }
           
        }
    }

}