using UnityEngine;

namespace MyFps
{
    // 게임 오버 처리 : 메뉴 가기, 다시 하기
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 커서 제어
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Fade In 효과
            fader.FadeStart();
        }
        #endregion

        #region Custom Method
        public void Retry()
        {
            fader.FadeTo(loadToScene);
        }

        public void Menu()
        {
            Debug.Log("Go To Menu!!!");
        }
        #endregion
    }
}