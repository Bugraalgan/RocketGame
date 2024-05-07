using UnityEngine;
public class engel : MonoBehaviour
{ 
    [SerializeField] float speed = 2.0f; // Engelin hızı
    [SerializeField] float minY = 2f;    // Y ekseni minimum sınırı
    [SerializeField] float maxY = 5f;
    
    private bool goingUp = true;         // Engelin yukarı mı yoksa aşağı mı gittiğini belirt n bir bayrak
    void Update()
    {
            // Engelin yönüne göre hedef yüksekliği belirle
            float targetY = goingUp ? maxY : minY;
            

            // Engeli hedef yüksekliğe doğru hareket ettir
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetY, transform.position.z), speed * Time.deltaTime);

            // Eğer engel hedef yüksekliğe ulaşırsa, yönü değiştir
            if (transform.position.y == targetY)
            {
                goingUp = !goingUp;
            }
    }
}