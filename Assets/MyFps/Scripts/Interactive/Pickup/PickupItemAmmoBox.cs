using UnityEngine;

namespace MyFps
{
    public class PickupItemAmmoBox : PickupItem
    {
        #region Variables
        // 아이템 먹는 효과
        [SerializeField]
        private int giveAmmo = 7;
        #endregion

        #region Custom Method
        protected override bool OnPickUp()
        {
            // Ammo Box 아이템을 먹을 수 있는지 체크
            // Ammo Box 아이템 먹었을 때의 효과 구현
            PlayerDataManager.Instance.AddAmmo(giveAmmo);

            return true;
        }
        #endregion
    }
}
/*
1. 플레이어가 부딪히는 충돌 체크 : 충돌하면
- 탄환 7개 지급
- 아이템 킬

2. 아이템 움직임 구현
- 아이템이 360도 회전
- 위아래로 왔다갔다 흔들림 구현 (Mathf : Sine 곡선 활용)
*/