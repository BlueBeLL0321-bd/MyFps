using UnityEngine;
using System.Collections;
using TMPro;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        // 플레이어 오브젝트
        public GameObject thePlayer;

        // 시나리오 대사 처리
        public TextMeshProUGUI sequenceText;

        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";

        // 화살표
        public GameObject theArrow;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 화살표 오브젝트 비활성화
            theArrow.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            this.GetComponent<Collider>().enabled = false;

            StartCoroutine(SequencePlayer());
        }
        #endregion

        #region Custom Method
        IEnumerator SequencePlayer()
        {
            // 1. 플레이 캐릭터 비활성화(플레이 멈춤)
            thePlayer.SetActive(false);

            // 2. 대사 출력
            sequenceText.text = sequence;

            // 3. 1초 딜레이
            yield return new WaitForSeconds(1f);

            // 4. 화살표 활성화
            theArrow.SetActive(true);

            // 5. 다시 1초 딜레이
            yield return new WaitForSeconds(1f);
            sequenceText.text = "";

            // 6. 플레이 캐릭터 활성화(다시 플레이)
            thePlayer.SetActive(true);
        }
        #endregion
    }
}