using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // --- CÁC BIẾN MỚI CHO SÚNG ---
    public GameObject bulletPrefab; // Chứa bản mẫu viên đạn
    public float fireRate = 0.2f;   // Tốc độ bắn (0.2s bắn 1 viên)
    private float nextFireTime = 0f; // Bộ đếm thời gian bắn
    // -----------------------------

    // --- CÁC BIẾN GIỚI HẠN MÀN HÌNH ---
    public float minX = -8f; // Giới hạn mép trái
    public float maxX = 8f;  // Giới hạn mép phải
    public float minY = -4f; // Giới hạn mép dưới
    public float maxY = 4f;  // Giới hạn mép trên
    // ----------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Lệnh Di chuyển (Giữ nguyên)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(moveX, moveY).normalized * moveSpeed;

        // 2. KẸP VỊ TRÍ: Chặn không cho bay ra ngoài
        Vector3 currentPos = transform.position;
        // Ép X nằm giữa khoảng minX và maxX
        currentPos.x = Mathf.Clamp(currentPos.x, minX, maxX);
        // Ép Y nằm giữa khoảng minY và maxY
        currentPos.y = Mathf.Clamp(currentPos.y, minY, maxY);
        // Cập nhật lại vị trí đã bị "kẹp" cho phi thuyền
        transform.position = currentPos;

        // 3. Lệnh Bắn súng (Nhấn giữ phím Space)
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            Shoot();
            // Cập nhật thời gian cho viên đạn tiếp theo
            nextFireTime = Time.time + fireRate; 
        }
    }

    void Shoot()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 0.8f, 0f); 
        
        // SỬ DỤNG Quaternion.Euler(0, 0, 90) ĐỂ ÉP VIÊN ĐẠN DỰNG ĐỨNG 90 ĐỘ (Trục Z)
        Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
    }
}