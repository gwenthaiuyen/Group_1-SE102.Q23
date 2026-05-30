using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI; // Dùng cho UI Canvas
using UnityEngine.SceneManagement; // Bộ quản lý chuyển cảnh chuẩn của Unity 6

namespace IrishFarmSim
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Giao Diện Mới (Kéo UI RawImage Background vào đây)")]
        public RawImage backgroundUI;

        [Header("Hình Ảnh Nền Cũ")]
        public Texture backgroundTexture;
        public Texture backgroundLoading;
        public Texture backgroundNoGame;

        [Header("Âm Thanh")]
        public AudioClip buttonSound;

        private bool isLoading = false;
        private Texture backgroundTemp;
        private AudioSource audioSource;

        void Start()
        {
            // Tự động lấy component AudioSource
            audioSource = GetComponent<AudioSource>();

            // Đặt ảnh nền mặc định lúc mới mở game
            if (backgroundUI != null && backgroundTexture != null)
            {
                backgroundUI.texture = backgroundTexture;
            }
        }

        void Update()
        {
            // Nhấn nút Escape (Esc) để thoát game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PlaySound();
                StartCoroutine(WaitFor(10));    // 10 là mã quy ước để thoát game
            }
        }

        // =================================================================
        // CÁC HÀM GẮN VÀO NÚT BẤM (BUTTON CLICK)
        // =================================================================

        public void Btn_NewGame_Click()
        {
            if (isLoading) return;

            PlaySound();
            // Dựa theo ảnh của bạn: Scene "Player Name" nằm ở vị trí số 2
            StartCoroutine(WaitFor(2));
        }

        public void Btn_LoadGame_Click()
        {
            if (isLoading) return;

            PlaySound();
            GameController.Instance().loadPlayer = true;

            // Kiểm tra file save (.dat)
            bool fileTest1 = File.Exists(Application.persistentDataPath + "/player.dat");
            bool fileTest2 = File.Exists(Application.persistentDataPath + "/cows.dat");

            if (fileTest1 || fileTest2)
            {
                // Dựa theo ảnh của bạn: Scene "Farm" nằm ở vị trí số 3
                StartCoroutine(WaitFor(3));
                isLoading = true;
                if (backgroundUI != null) backgroundUI.texture = backgroundLoading;
            }
            else
            {
                StartCoroutine(WaitForSec(3));
                isLoading = true;
                if (backgroundUI != null)
                {
                    backgroundTemp = backgroundUI.texture;
                    backgroundUI.texture = backgroundNoGame; // Đổi sang ảnh "No Game Found!"
                }
            }
        }

        // Thêm sẵn hàm cho nút Cài đặt (nếu sau này bạn muốn nối vào)
        public void Btn_Settings_Click()
        {
            if (isLoading) return;

            PlaySound();
            // Dựa theo ảnh của bạn: Scene "Settings" nằm ở vị trí số 1
            StartCoroutine(WaitFor(1));
        }

        public void Btn_Exit_Click()
        {
            if (isLoading) return;

            PlaySound();
            StartCoroutine(WaitFor(10)); // Truyền số 10 để gọi lệnh thoát game
        }

        // =================================================================
        // CÁC HÀM XỬ LÝ HỆ THỐNG
        // =================================================================

        private void PlaySound()
        {
            if (audioSource != null && buttonSound != null)
            {
                audioSource.PlayOneShot(buttonSound, 0.6f);
            }
        }

        private IEnumerator WaitFor(int level)
        {
            // Đợi 1 giây để tiếng âm thanh click chuột kịp phát xong rồi mới chuyển màn hình
            yield return new WaitForSeconds(1.0f);

            if (level == 10)
            {
                Application.Quit(); // Lệnh thoát game
            }
            else
            {
                // LỆNH CHUYỂN CẢNH MỚI CHO UNITY 6
                SceneManager.LoadScene(level);
            }
        }

        private IEnumerator WaitForSec(int seconds)
        {
            // Đợi vài giây rồi trả lại màn hình nền mặc định (dùng khi báo lỗi No Game Found)
            yield return new WaitForSeconds(seconds);
            isLoading = false;

            if (backgroundUI != null && backgroundTemp != null)
            {
                backgroundUI.texture = backgroundTemp;
            }
        }
    }
}