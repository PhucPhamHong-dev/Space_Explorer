using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện dùng để quản lý chuyển Scene

public class MainMenuController : MonoBehaviour
{
    // Hàm này sẽ được gọi khi nhấn nút Play
    public void PlayGame()
    {
        // Tải Scene có tên là "Gameplay"
        SceneManager.LoadScene("Gameplay");
    }

    // Hàm này sẽ được gọi khi nhấn nút Instructions (Tạm thời in ra log)
    public void ShowInstructions()
    {
        Debug.Log("Hiển thị bảng hướng dẫn!");
    }
}