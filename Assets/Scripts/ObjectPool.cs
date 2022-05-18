using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance { get; private set; }
    private Queue<GameObject> pooledObjects = new Queue<GameObject>();
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddObjects(amountToPool);
    }

    public GameObject Get()
    {
        if (pooledObjects.Count == 0)
        {
            AddObjects(1);
        }

        return pooledObjects.Dequeue();
    }

    private void AddObjects(int count)
    {
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(prefab);
            tmp.SetActive(false);
            pooledObjects.Enqueue(tmp);
            tmp.GetComponent<IGameObjectPooled>().Pool = this;
        }
    }

    public void ReturnToPool (GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        pooledObjects.Enqueue(objectToReturn);
    }
}
