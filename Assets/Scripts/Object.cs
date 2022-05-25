using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]

public class Object : MonoBehaviour
{
    public float spawnPosY = -6;
    public float xRange = 12;
    public float minSpeed = 12.0f;
    public float maxSpeed = 16.0f;
    public float maxTorque = 10.0f;
    public float yRange = -8;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        ThrowUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yRange)
        {
            CheckBottomBoundary();
        }
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

    // Destroy gameObject when clicked;
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    public virtual void CheckBottomBoundary()
    {
        Destroy(gameObject);
    }
}
