using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MyFps
{
    // 신 시작 시 페이드 인, 신 종료 시 페이드 아웃 효과 구현
    public class SceneFader : MonoBehaviour
    {
        #region Field
        // 페이더 이미지
        public Image img;

        // 애니메이션 커브
        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            // 초기화 : 페이드 이미지
            img.color = new Color(0f, 0f, 0f, 1f);

            // 페이드 인
            // StartCoroutine(FadeIn(fadeInDelay));
        }

        // 코루틴으로 구현
        // delayTime : 매개 변수로 딜레이 타임 받아 딜레이 후 페이드 효과
        // Fade In : 1초 동안 : 검정에서 완전 투명으로(이미지 알파 값 a : 1 -> a : 0)
        IEnumerator FadeIn(float delayTime = 0f)
        {
            // delayTime 지연
            if(delayTime > 0)
            {
                yield return new WaitForSeconds(delayTime);
            }
            
            float t = 1f;

            while (t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f; // 한 프레임 지연
            }
        }

        // Fade Out : 1초 동안 : 투명에서 완전 검정으로(이미지 알파 값 a : 0 -> a : 1)
        IEnumerator FadeOut()
        {
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }
        }

        // 페이드 인 외부에서 호출
        public void FadeStart(float delayTime)
        {
            StartCoroutine(FadeIn(delayTime));
        }

        // Fade Out 효과 후 매개 변수로 받은 신 이름으로 LoadScene으로 이동
        IEnumerator FadeOut(string sceneName)
        {
            // Fade Out 효과 후
            float t = 0f;


            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }


            // 신 이동
            if(sceneName != "")
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        
        // 다른 신으로 이동 시 호출
        public void FadeTo(string sceneName = "")
        {
            StartCoroutine(FadeOut(sceneName));
        }

    }
}