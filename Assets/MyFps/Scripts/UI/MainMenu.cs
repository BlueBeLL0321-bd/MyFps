using UnityEngine;

namespace MyFps
{
    // 메인 메뉴 신을 관리하는 클래스
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainScene01";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 신 시작 시 페이드 인 효과
            fader.FadeStart();
        }
        #endregion

        #region Custom Method
        public void NewGame()
        {
            // 새 게임 하러 가기
            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game!!!");
        }

        public void Options()
        {
            Debug.Log("Show Options!!!");
        }

        public void Credits()
        {
            Debug.Log("Show Credits!!!");
        }

        public void QuitGame()
        {
            Debug.Log("Quit Game!!!");
        }
        #endregion
    }
}

