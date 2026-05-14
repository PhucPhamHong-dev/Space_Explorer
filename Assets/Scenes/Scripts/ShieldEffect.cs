using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public float blinkSpeed = 10f; // Tốc độ nhấp nháy (số càng to nháy càng nhanh)
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        // Lấy component màu sắc của cái khiên
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Lưu lại màu gốc bạn đã pha ở Inspector
        originalColor = spriteRenderer.color;
        
        // Vẫn giữ lệnh tự hủy sau 2 giây
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Tạo giá trị nhấp nháy chạy lên chạy xuống liên tục từ 0 đến màu gốc
        // Dùng Mathf.PingPong kết hợp với Time.time
        float blinkAlpha = Mathf.PingPong(Time.time * blinkSpeed, originalColor.a);
        
        // Áp dụng độ trong suốt mới vào khiên
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, blinkAlpha);
    }
}