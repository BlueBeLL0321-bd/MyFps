using UnityEngine;

namespace MyFps
{
    // 트리거에 들어오면 플레이어가 안전 지역에 있다 저장
    public class SafeZoneInTrigger : MonoBehaviour
    {
        #region Variables
        // SafeZoneOutTrigger 오브젝트
        public GameObject SafeZoneOutTrigger;
        #endregion

        #region Unity Event Method
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerController.safeZoneIn = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                // SafeZoneOutTrigger 활성화
                SafeZoneOutTrigger.SetActive(true);

                // SafeZoneInTrigger 비활성화
                this.gameObject.SetActive(false);
            }
        }
        #endregion

    }
}

