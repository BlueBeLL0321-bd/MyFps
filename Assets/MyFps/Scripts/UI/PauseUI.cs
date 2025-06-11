using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFps
{
    // 게임 중 메뉴 관리 클래스
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;
        public PlayerInput playerInput;

        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        private bool isMenuGoing = false;
        #endregion

        #region Custom Method
        // New Input 연결
        public void OnPause(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                Toggle();
            }
        }

        // Esc키 누르면 UI 활성화, 다시 Esc키 누르면 UI 비활성화 - 토글 키
        public void Toggle()
        {
            if (isMenuGoing)
                return;

            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf) // 창이 열린 상태
            {
                Time.timeScale = 0f;
                
                // 커서 제어
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else // 창이 닫힌 상태
            {
                Time.timeScale = 1f;
                
                // 커서 제어
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // 메뉴 가기 버튼 호출
        public void Menu()
        {
            if (isMenuGoing)
                return;

            isMenuGoing = true;

            Time.timeScale = 1f;
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}

