using UnityEngine;
using System.Collections;

namespace MyFps
{
    // 타이틀 신을 관리하는 클래스 : 3초 후에 Any Key 보이고 10초 후에 메인 메뉴 가기
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        private bool isShow = false;    // Any Key가 보이나?
        public GameObject anyKey;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 페이드 인 효과
            fader.FadeStart();

            // 배경음 플레이
            AudioManager.Instance.PlayBgm("TitleBgm");

            // 코루틴 함수 실행
            StartCoroutine(TitleProcess());
        }

        private void Update()
        {
            // Any Key가 보인 후에 아무 키나 누르면 메인 메뉴 가기 - Old Input
            if(Input.anyKeyDown && isShow)
            {
                StopAllCoroutines();
                fader.FadeTo(loadToScene);
            }
        }
        #endregion

        #region Custom Method
        // 코루틴 함수 : 3초 후에 Any Key 보이고 10초 후에 메인 메뉴 가기
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(3f);

            isShow = true;
            anyKey.SetActive(true);

            yield return new WaitForSeconds(10f);

            AudioManager.Instance.Stop("TitleBgm");
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}

