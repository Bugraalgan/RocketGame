using System;
using UnityEngine;
public class kuphareket : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] Vector3 movementVector;
     Vector3 startingposition;

    void Start()
    {
        startingposition = transform.position;
    }

    void Update()
    {
        Vector3 offset = movementFactor * movementVector;
        transform.position=offset+startingposition;
    }
}
