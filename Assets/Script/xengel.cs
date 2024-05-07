using UnityEngine;
public class xengel : MonoBehaviour
{ 
    [SerializeField] float speed = 2.0f; // Engelin hızı
    [SerializeField] float minX = 2f;    // Y ekseni minimum sınırı
    [SerializeField] float maxX = 5f;
    
    private bool goingUp = true;         // Engelin yukarı mı yoksa aşağı mı gittiğini belirt n bir bayrak
    void Update()
    {
        // Engelin yönüne göre hedef yüksekliği belirle
        float targetX = goingUp ? maxX : minX;
            

        // Engeli hedef yüksekliğe doğru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);

        // Eğer engel hedef yüksekliğe ulaşırsa, yönü değiştir
        if (transform.position.x == targetX)
        {
            goingUp = !goingUp;
        }
    }
}