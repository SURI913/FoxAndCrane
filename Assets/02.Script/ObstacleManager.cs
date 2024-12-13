using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : MonoBehaviour
{
    public class ObstaclePool
    {
        public string typeName;
        public GameObject prefab;
        public int poolSize;
    }

    public List<ObstaclePool> obstaclePools; // ��ֹ� Ǯ ����Ʈ
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (ObstaclePool pool in obstaclePools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.typeName, objectPool);
        }
    }

    public GameObject SpawnObstacle(string typeName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(typeName))
        {
            Debug.LogWarning($"Ǯ�� {typeName} ������ �����ϴ�.");
            return null;
        }

        GameObject objToSpawn = poolDictionary[typeName].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolDictionary[typeName].Enqueue(objToSpawn);

        return objToSpawn;
    }
    public void ReturnObstacle(string typeName, GameObject obstacle)
    {
        if (!poolDictionary.ContainsKey(typeName))
        {
            //Ǯ�� ������ ��� �� ���� 
            Debug.Log($"Ǯ�� {typeName} ������ �����ϴ�.");
            Destroy(obstacle); 
            return;
        }

        obstacle.SetActive(false);

        poolDictionary[typeName].Enqueue(obstacle); // ��ȯ�Ȱ� �ٽ� �־���
    }
}