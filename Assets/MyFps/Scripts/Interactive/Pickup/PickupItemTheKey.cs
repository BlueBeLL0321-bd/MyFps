using UnityEngine;

namespace MyFps
{
    public class PickupItemTheKey : PickupItem
    {

        #region Custom Method
        protected override bool OnPickUp()
        {
            return true;
        }
        #endregion
    }
}

