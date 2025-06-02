using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace MyFps
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        // 플레이어 제어 관리
        public PlayerInput playerInput;
        // 연출 오브젝트
        public GameObject activityObject;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            activityObject.SetActive(false);
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
            playerInput.enabled = false;        // 인풋 제어
            activityObject.SetActive(true);     // 연출 시작

            yield return new WaitForSeconds(0.2f);
            activityObject.SetActive(false);

            yield return new WaitForSeconds(2f);

            playerInput.enabled = true;

        }
        #endregion
    }
}