using UnityEngine;
using System.Collections;

namespace MyFps
{
    // 공격을 받으면(대미지 입으면) 오브젝트가 부서진다
    // 오브젝트 부서지는 연출, 두 번 다시 공격을 받지 않아야 된다
    // 부서질 때 그릇 깨지는 사운드 플레이
    // 아이템(Key) 숨기기
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject fakeObject;   // 온전한 오브젝트
        public GameObject realObject;   // 부서지는 오브젝트
        public GameObject sphereObject; // 액티브 연출용 오브젝트

        private bool isDeath = false;   // 두 번 죽는 것 체크
        private float health = 1f;

        [SerializeField]
        private bool unbreakable = false;   // 깨지지 않는 오브젝트

        // 숨겨진 아이템
        public GameObject hiddenItemPrefab;
        [SerializeField]
        private Vector3 offset;

        public GameObject hiddenItem;
        #endregion

        #region Custom Method
        public void TakeDamage(float damage)
        {
            // 무적 모드
            if (unbreakable)
                return;

            health -= damage;

            if(health <= 0f && isDeath == false)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;

            // 깨지는 연출
            StartCoroutine(Break());
        }

        IEnumerator Break()
        {
            // 충돌체 제거
            this.GetComponent<BoxCollider>().enabled = false;

            // 깨지는 오브젝트 보이기
            fakeObject.SetActive(false);

            if(sphereObject)
            {
                yield return new WaitForSeconds(0.1f);
                sphereObject.SetActive(true);
            }
            realObject.SetActive(true);

            // 사운드
            AudioManager.Instance.Play("PotterySmash");

            if(sphereObject)
            {
                yield return new WaitForSeconds(0.1f);
                sphereObject.SetActive(false);
            }

            // 숨겨진 아이템 나타내기
            if(hiddenItem)
            {
                hiddenItem.SetActive(true);
            }
        }
        #endregion
    }
}

