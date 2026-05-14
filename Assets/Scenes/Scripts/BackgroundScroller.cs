using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 2f; 
    private float height;
    private Vector3 startPos;
    private GameObject cloneBg; // Biến chứa tấm ảnh bản sao

    void Start()
    {
        // Ghi nhớ vị trí xuất phát
        startPos = transform.position;
        
        // Đo chiều cao thực tế của tấm ảnh
        height = GetComponent<SpriteRenderer>().bounds.size.y;

        // TỰ ĐỘNG: Nhân bản tấm ảnh hiện tại
        cloneBg = Instantiate(gameObject);
        
        // Xóa script ở bản sao để nó không tự nhân bản đẻ ra thêm nữa
        Destroy(cloneBg.GetComponent<BackgroundScroller>());
        
        // TỰ ĐỘNG: Đặt bản sao lên ngay trên đỉnh tấm ảnh gốc khít 100%
        cloneBg.transform.position = new Vector3(startPos.x, startPos.y + height, startPos.z);
    }

    void Update()
    {
        // Di chuyển cả 2 tấm ảnh xuống dưới
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        cloneBg.transform.Translate(Vector3.down * speed * Time.deltaTime);

        // VÒNG LẶP VÔ TẬN:
        // Nếu tấm 1 trôi qua hết, lập tức bốc nó đặt lên trên đỉnh tấm 2
        if (transform.position.y < startPos.y - height)
        {
            transform.position = new Vector3(startPos.x, cloneBg.transform.position.y + height, startPos.z);
        }
        
        // Nếu tấm 2 trôi qua hết, lập tức bốc nó đặt lên trên đỉnh tấm 1
        if (cloneBg.transform.position.y < startPos.y - height)
        {
            cloneBg.transform.position = new Vector3(startPos.x, transform.position.y + height, startPos.z);
        }
    }
}