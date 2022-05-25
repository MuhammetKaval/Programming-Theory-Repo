using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Base class for all Fruit and Bomb class. It will Throw up object when Instantiate
// It require a Rigidbody to Throw up the object.
[RequireComponent(typeof(Rigidbody))]

public class Object : MonoBehaviour

// INHERITANCE
{
    protected float spawnPosY = -6;
    protected float xRange = 12;
    protected float minSpeed = 12.0f;
    protected float maxSpeed = 16.0f;
    protected float maxTorque = 10.0f;
    protected float yRange = -8;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // ABSTRACTION
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
        // ABSTRACTION
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

    // POLYMORPHISM
    // Destroy gameObject when clicked;
    public virtual void OnMouseDown()
    {
        Destroy(gameObject);
    }

    // POLYMORPHISM
    public virtual void CheckBottomBoundary()
    {
        Destroy(gameObject);
    }
}
