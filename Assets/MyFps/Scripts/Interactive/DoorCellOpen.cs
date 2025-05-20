using UnityEngine;
using TMPro;
using System.Collections;

namespace MyFps
{
    // 문 열기 인터렉티브 액션 구현
    public class DoorCellOpen : Interactive
    {
        #region Variables
        // 애니메이션
        public Animator animator;

        // 애니메이션 파라미터
        private string paramIsOpen = "IsOpen";
        #endregion

        #region Custom Method
        protected override void DoAction()
        {
            // 문 열기, 충돌체 제거
            animator.SetBool(paramIsOpen, true);                // 문 열기 연출
            this.GetComponent<BoxCollider>().enabled = false;   // 충돌체 제거
        }
        #endregion
    }
}

