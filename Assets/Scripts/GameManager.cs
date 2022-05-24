using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float spawnRate = 2.0f;
    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(parentObject);
        }
    }

}
