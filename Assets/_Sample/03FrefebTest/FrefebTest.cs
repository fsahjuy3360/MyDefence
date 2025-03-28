using UnityEngine;
using System.Collections;

namespace Sample
{
    public class FrefebTest : MonoBehaviour
    {
        public GameObject tilePrefab;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //[1] 하나 생성
            //Vector3 position = new Vector3(5f, 0f, 0f);
            //Instantiate(tilePrefab, position, Quaternion.identity);

            //[2] n(10) x m(10) 생성 - 5 x 5, 7 x 7
            //GenerateMap(10, 10);
            //GenerateMap2(10, 10);

            //[3] 타일을 생성 - x좌표를 0~500 사이의 랜덤값, y = 0, z 좌표를 -500~0사이의 랜덤값
           /* for (int i = 0; i < 10; i++)
            {
                GenerateRamdomMapTile();
            }*/

            //[4] 타일을 10개 생성, 타일 하나 생성할 때 마다 딜레이 0.2초 준다
            // 코루틴 (Coroutine) - 0.2초 지연 
            StartCoroutine(GenerateRandomMap());


        }

       

        void GenerateMap(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(j * 5f, 0f, i * -5f);
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }

        }

        void GenerateMap2(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                   GameObject go = Instantiate(tilePrefab, this.transform);
                    go.transform.position = new Vector3(j * 5f, 0f, i * -5f);
                }
            }

        }

        void GenerateRamdomMapTile()
        {
            float Xpos = Random.Range(0f, 50f);
            float Zpos = Random.Range(-50f, 0f);
            Vector3 position = new Vector3(Xpos, 0f, Zpos);
            Instantiate(tilePrefab, position, Quaternion.identity);
        }

       
        IEnumerator GenerateRandomMap()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 position = new Vector3(Random.Range(0f, 50f), 0f, Random.Range(-50f, 0f));
                Instantiate(tilePrefab, position, Quaternion.identity);

                // 0.2초 딜레이
                yield return new WaitForSeconds(0.2f);

            }
        }
    }
}