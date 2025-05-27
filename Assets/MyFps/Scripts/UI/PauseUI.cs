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
            Debug.Log("Go To Menu!!!");
        }
        #endregion
    }
}

