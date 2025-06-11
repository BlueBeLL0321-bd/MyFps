using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace MyFps
{
    // 메인 2번 신 오프닝 클래스
    public class DOpening : MonoBehaviour
    {
        #region Variables
        // 플레이어 오브젝트
        public GameObject thePlayer;

        // 페이더 객체
        public SceneFader fader;

        // 시나리오 대사 처리
        public TextMeshProUGUI sequenceText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            /*// 게임 데이터(신 번호) 저장
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SaveScene", sceneNumber);*/

            // File System 모드
            PlayerDataManager.Instance.SceneNumber = SceneManager.GetActiveScene().buildIndex;
            SaveLoad.SaveData();

            // 커서 제어
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // 시퀀스 플레이
            StartCoroutine(SequencePlay());
        }
        #endregion

        #region Custom Method
        IEnumerator SequencePlay()
        {
            // 0. 플레이어 캐릭터 비활성화
            PlayerInput input = thePlayer.GetComponent<PlayerInput>();
            input.enabled = false;

            // 1. 페이드 인 연출 (1초 대기 후 페이드 인 효과)
            fader.FadeStart(0.5f);

            // 2. 화면 하단에 시나리오 텍스트 빈 값 초기화
            sequenceText.text = "";

            yield return new WaitForSeconds(1f);

            // TODO : Cheating
            // 메인 2번 신 설정
            PlayerDataManager.Instance.Weapon = WeaponType.Pistol;

            // 3. 배경음 플레이 시작
            AudioManager.Instance.PlayBgm("Bgm02");

            // 4. 플레이어 캐릭터 활성화
            input.enabled = true;
        }
        #endregion
    }
}