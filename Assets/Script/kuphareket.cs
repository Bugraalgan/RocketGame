using System;
using UnityEngine;
public class kuphareket : MonoBehaviour
{
    float movementFactor;
    [SerializeField] Vector3 movementVector;
    Vector3 startingposition;
    [SerializeField] private float period = 2f;

    void Start()
    {
        startingposition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time / period;
        const double tau = Math.PI * 2;
        double rawSinWawe = Math.Sin(cycles * tau);
        movementFactor = (float)((rawSinWawe + 1) / 2);
        Vector3 offset = movementFactor * movementVector;
        transform.position=offset+startingposition;
    }
}
