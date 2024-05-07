using UnityEngine;


public class donenengel : MonoBehaviour
{ 
    [SerializeField] float donmehızı=2f;
    [SerializeField] float xDegeri = 0f;
    [SerializeField] float yDegeri = 0f;
    [SerializeField] float zDegeri = 0f;
    void Update()
    {
        transform.Rotate(xDegeri*donmehızı,yDegeri*donmehızı,zDegeri*donmehızı);

    }
}
