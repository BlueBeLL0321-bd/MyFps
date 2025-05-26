using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        // 플레이어 오브젝트
        public GameObject thePlayer;

        // 화살표
        public GameObject theArrow;

        // 시나리오 대사 처리
        public TextMeshProUGUI sequenceText;

        [SerializeField]
        private string sequence = "Looks like there's a weapon on that table.";

        // 대사 음성
        public AudioSource line03;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 화살표 오브젝트 비활성화
            theArrow.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            // 플레이어 체크
            if (other.tag == "Player")
            {
                // 트리거 해제
                this.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(SequencePlayer());
            }
        }
        #endregion

        #region Custom Method
        IEnumerator SequencePlayer()
        {
            // 1. 플레이 캐릭터 비활성화(플레이 멈춤)
            PlayerInput input = thePlayer.GetComponent<PlayerInput>();
            input.enabled = false;

            // 2. 대사 출력 : "Looks like there's a weapon on that table."
            sequenceText.text = sequence;
            line03.Play();

            // 3. 1초 딜레이
            yield return new WaitForSeconds(1f);

            // 4. 화살표 활성화
            theArrow.SetActive(true);

            // 5. 2초 딜레이
            yield return new WaitForSeconds(2f);
            sequenceText.text = "";

            // 6. 플레이 캐릭터 활성화(다시 플레이)
            input.enabled = true;
        }
        #endregion
    }
}