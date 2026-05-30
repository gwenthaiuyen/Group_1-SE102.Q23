using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace IrishFarmSim
{
    public class SettingsMenu : MonoBehaviour
    {
        [Header("Thanh Trượt Âm Lượng (Sliders)")]
        public Slider fxSlider;
        public Slider musicSlider;

        [Header("Âm Thanh")]
        public AudioClip buttonSound;

        private AudioSource audioSource;
        private bool isLoading = false;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            // Lấy dữ liệu cài đặt đang có sẵn trong GameController truyền vào Slider
            if (GameController.Instance() != null)
            {
                if (fxSlider != null) fxSlider.value = GameController.Instance().fxLevel;
                if (musicSlider != null) musicSlider.value = GameController.Instance().musicLevel;
            }
        }

        // =================================================================
        // CÁC HÀM XỬ LÝ THANH TRƯỢT (SLIDER)
        // =================================================================

        public void OnFXSliderChanged()
        {
            if (GameController.Instance() != null && fxSlider != null)
            {
                GameController.Instance().fxLevel = fxSlider.value; // Lưu âm lượng FX
            }
        }

        public void OnMusicSliderChanged()
        {
            if (GameController.Instance() != null && musicSlider != null)
            {
                GameController.Instance().musicLevel = musicSlider.value; // Lưu âm lượng Nhạc nền
            }
        }

        // =================================================================
        // CÁC HÀM XỬ LÝ NÚT BẤM (BUTTON)
        // =================================================================

        public void Btn_Done_Click()
        {
            if (isLoading) return;
            isLoading = true;
            PlaySound();

            // Tùy chọn: Lưu âm lượng vào bộ nhớ máy để lần sau mở game không bị reset
            PlayerPrefs.SetFloat("FXLevel", fxSlider != null ? fxSlider.value : 0.5f);
            PlayerPrefs.SetFloat("MusicLevel", musicSlider != null ? musicSlider.value : 0.5f);
            PlayerPrefs.Save();

            // Chuyển về Main Menu (Vị trí số 0)
            StartCoroutine(WaitFor(0));
        }

        private void PlaySound()
        {
            if (audioSource != null && buttonSound != null)
            {
                audioSource.PlayOneShot(buttonSound, 0.6f);
            }
        }

        private IEnumerator WaitFor(int level)
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(level);
        }
    }
}