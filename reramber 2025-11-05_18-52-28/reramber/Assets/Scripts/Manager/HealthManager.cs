using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //====================================================================
    [Header("Health Settings")]
    [SerializeField]
    private float maxHealth = 100f; // 최대 HP

    private float currentHealth;    // 현재 HP

    public bool IsDead { get; private set; } = false; // 사망 상태

    private void Awake()
    {
        currentHealth = maxHealth; // 게임 시작 시 최대 HP로 초기화
    }

    //==================================================================
    /// <summary>
    /// 외부로부터 피해(데미지)를 받아 현재 HP를 감소시키는 함수입니다.
    /// </summary>
    /// <param name="damageAmount">받은 피해량</param>
    public void TakeDamage(float damageAmount)
    {
        // 이미 사망했다면 함수 실행 중지
        if (IsDead)
        {
            Debug.Log(gameObject.name + "은(는) 이미 사망했습니다!");
            return;
        }

        // HP 감소 (음수 데미지를 방지하기 위해 Mathf.Abs 사용)
        currentHealth -= Mathf.Abs(damageAmount);

        // HP가 0 미만으로 내려가지 않도록 보정
        currentHealth = Mathf.Max(currentHealth, 0f);

        Debug.Log(
            $"{gameObject.name}이(가) 데미지 {damageAmount:F1}를 받았습니다. " +
            $"남은 HP: {currentHealth:F1}/{maxHealth:F1}"
        );

        //사망 체크
        if (currentHealth <= 0 && !IsDead)
        {
            Die();
        }
    }

    /// <summary>
    /// 체력을 회복하는 함수입니다.
    /// </summary>
    /// <param name="healAmount">회복량</param>
    public void Heal(float healAmount)
    {
        if (IsDead) return;

        // HP 증가 및 최대 HP를 초과하지 않도록 보정
        currentHealth += Mathf.Abs(healAmount);
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log($"체력을 {healAmount:F1} 회복했습니다. 현재 HP: {currentHealth:F1}");
    }

    // 캐릭터 사망 처리 함수
    private void Die()
    {
        IsDead = true;
        Debug.Log(gameObject.name + " 사망!");

        // 사망 애니메이션, 물리 효과 비활성화, UI 표시 등 사망 관련 로직 추가

        // 예시: 캐릭터의 Collider를 비활성화하여 추가 충돌 방지
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
    }
}
