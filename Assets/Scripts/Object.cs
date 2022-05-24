using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float spawnPosY = -6;
    public float xRange = 12;
    public float minSpeed = 12.0f;
    public float maxSpeed = 16.0f;
    public float maxTorque = 10.0f;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        ThrowUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowUp()
    {
        SetRandomPosition();
        AddRandomForce();
        AddRandomTorque();
    }

    public void SetRandomPosition()
    {
        float randomPosX = Random.Range(-xRange, xRange);
        transform.position = new Vector3(randomPosX, spawnPosY, 0);
    }

    public void AddRandomForce()
    {
        float randomForceValue = Random.Range(minSpeed, maxSpeed);
        rigidbody.AddForce(Vector3.up * randomForceValue, ForceMode.Impulse);
    }

    public void AddRandomTorque()
    {
        float randomTorqueValueX = Random.Range(-maxTorque, maxTorque);
        float randomTorqueValueY = Random.Range(-maxTorque, maxTorque);
        float randomTorqueValueZ = Random.Range(-maxTorque, maxTorque);
        rigidbody.AddTorque(randomTorqueValueX, randomTorqueValueY, randomTorqueValueZ, ForceMode.Impulse);
    }
}
