using UnityEngine;
using System.Collections;

namespace MyFps
{
    // 플레이어의 체력을 관리하는 클래스
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        #region Variables
        // 체력
        private float currentHealth;
        private bool isDeath = false;

        // 대미지 효과
        public GameObject damageFlash;

        public AudioSource hurt01;
        public AudioSource hurt02;
        public AudioSource hurt03;

        // 죽음 처리
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "GameOver";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            // 초기화
            currentHealth = PlayerDataManager.Instance.PlayerHealth;
        }
        #endregion

        #region Custom Method
        // 플레이어 대미지
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            PlayerDataManager.Instance.PlayerHealth = currentHealth;

            // 대미지 연출 Sfx, Vfx
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && isDeath == false)
            {
                Die();
            }
        }

        // 화면 전체 빨간색 플래시 효과
        // 대미지 사운드 3개 중 1개 랜덤 발생
        IEnumerator DamageEffect()
        {
            // Vfx
            damageFlash.SetActive(true);
            // 카메라 흔들기
            CinemachineCameraShake.Instance.Shake(2f, 1f, 0.75f);

            // Sfx
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                hurt01.Play();
            }
            else if (randNum == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);
            damageFlash.SetActive(false);
        }

        private void Die()
        {
            isDeath = true;

            // TODO : 게임 오버 시 플레이한 신 번호 저장


            // 죽음 처리
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}

