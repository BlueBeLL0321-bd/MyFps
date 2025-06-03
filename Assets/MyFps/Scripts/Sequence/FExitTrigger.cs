using UnityEngine;

namespace MyFps
{
    // 트리거가 작동하면 메인 메뉴 보내기
    public class FExitTrigger : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";
        #endregion

        #region Unity Event Method
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                SceneClear();
            }
        }
        #endregion

        #region Custom Method
        private void SceneClear()
        {
            // BGM 정지
            AudioManager.Instance.StopBgm();

            // 메인 메뉴 가기, 커서 제어
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 메인 메뉴 가기
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}