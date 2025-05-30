using UnityEngine;

namespace MyFps
{
    public class PickupItemTheKey : PickupItem
    {
        #region Variables
        #endregion

        #region Custom Method
        protected override bool OnPickUp()
        {
            // 퍼즐 아이템(Key) 획득
            Debug.Log("퍼즐 아이템(Key) 획득");

            return true;
        }
        #endregion
    }
}

