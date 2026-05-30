using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Bắt buộc phải có dòng này để dùng ô nhập chữ TextMeshPro

namespace IrishFarmSim
{
    public class PlayerNameMenu : MonoBehaviour
    {
        [Header("Giao Diện UI Mới")]
        public RawImage backgroundUI;
        public TMP_InputField playerNameInput; // Ô để người chơi gõ tên vào

        [Header("Hình Ảnh Nền Cũ")]
        public Texture backgroundTexture;
        public Texture backgroundLoading;

        [Header("Âm Thanh")]
        public AudioClip buttonSound;

        private bool isLoading = false;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            // Đặt ảnh nền mặc định
            if (backgroundUI != null && backgroundTexture != null)
            {
                backgroundUI.texture = backgroundTexture;
            }

            // Tự động điền sẵn tên "Joe" giống như bản cũ của bạn
            if (playerNameInput != null)
            {
                playerNameInput.text = "Joe";
            }
        }

        void Update()
        {
            // Bấm nút Esc để quay lại Main Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isLoading) return;
                PlaySound();
                StartCoroutine(WaitFor(0)); // 0 là Scene Main Menu
            }
        }

        // =================================================================
        // CÁC HÀM GẮN VÀO NÚT BẤM CỦA CANVAS
        // =================================================================

        public void Btn_Play_Click()
        {
            if (isLoading) return;
            isLoading = true;
            PlaySound();

            // 1. Lấy tên từ ô nhập chữ của người chơi
            string playerName = "Joe"; // Tên dự phòng nếu người chơi không gõ gì
            if (playerNameInput != null && !string.IsNullOrEmpty(playerNameInput.text))
            {
                playerName = playerNameInput.text;
            }

            // 2. GIỮ NGUYÊN 100% LOGIC TẠO NHÂN VẬT CỦA BẠN
            GameController._instance.player = new Farmer("Farmer", 25000, 0, 0, 0, 0, GameController.Instance().gameDifficulty, GameController.Instance().fxLevel);
            GameController.Instance().player.name = playerName;
            GameController.Instance().newGame = true;

            // 3. Đổi ảnh nền sang Loading
            if (backgroundUI != null && backgroundLoading != null)
            {
                backgroundUI.texture = backgroundLoading;
            }

            // 4. Chuyển sang Scene Nông Trại (Vị trí số 3 trong Build Profiles)
            StartCoroutine(WaitFor(3));
        }

        public void Btn_Back_Click()
        {
            if (isLoading) return;
            PlaySound();

            // Quay lại Main Menu (Vị trí số 0)
            StartCoroutine(WaitFor(0));
        }

        // =================================================================
        // XỬ LÝ HỆ THỐNG
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
            yield return new WaitForSeconds(1.0f);

            if (level == 10)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}