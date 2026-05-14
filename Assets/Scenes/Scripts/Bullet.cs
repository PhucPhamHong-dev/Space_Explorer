using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f; // Tốc độ bay của đạn

    void Start()
    {
        // Tự động xóa viên đạn sau 3 giây để máy tính không bị quá tải
        Destroy(gameObject, 3f);
    }

   void Update()
    {
        // Dùng Vector3.up kết hợp Space.World để đạn bắt buộc bay theo trục dọc của màn hình
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}