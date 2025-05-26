using UnityEngine;

namespace MyFps
{
    // 제네릭 싱글톤 클래스 : 신 전환 시 파괴되지 않는다
    public class PersistentSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();

            // 신 전환 시 파괴되지 않는다
            DontDestroyOnLoad(gameObject);
        }
    }
}

