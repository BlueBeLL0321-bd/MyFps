using TMPro;
using UnityEngine;

namespace MyFps
{
    // 아이템(권총) 획득 인터렉티브 구현
    public class PickupPistol : Interactive
    {
        #region Variables
        // 인터렉티브 액션 연출
        public GameObject realPistol;
        public GameObject theArrow;
        #endregion

        #region Variables
        protected override void DoAction()
        {
            // 무기 획득, 충돌체 제거
            realPistol.SetActive(true);
            theArrow.SetActive(false);

            this.gameObject.SetActive(false);   // Fake Pistol 및 충돌체 제거
        }
        #endregion
    }
}