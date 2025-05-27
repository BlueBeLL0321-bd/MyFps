using UnityEngine;

namespace MyFps
{
    // 다음 신 넘어가기, 문을 열면 문 여는 소리, 배경음 종료, 다음 신으로 이동
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainScene02";

        public Animator animator; // 문 여는 애니메이션
        [SerializeField]
        private string isOpen = "IsOpen";

        public AudioSource doorBang;    // 문 여는 소리
        public AudioSource bgm01;       // 배경음
        #endregion

        #region Custom Method
        protected override void DoAction()
        {
            this.GetComponent<BoxCollider>().enabled = false;

            // 문을 열면
            animator.SetBool(isOpen, true);

            // 배경음 종료
            bgm01.Stop();

            // 문 여는 소리 플레이
            doorBang.Play();

            // 신 종료 시 처리할 내용 구현
            // ...

            // 다음 신으로 이동
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}

