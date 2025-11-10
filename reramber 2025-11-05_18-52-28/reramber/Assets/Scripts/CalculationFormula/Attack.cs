using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CalculationFormula
{
    int attack;
    private Coroutine dotCoroutine = null;
    public int BasicAttack()
    {
        return attack;
    }
    public float SpecialAttack()
    {
        return attack * 1.2f;
    }
/// <summary>
/// 도트데미지 시작
/// </summary>
/// <param name="지속시간"></param>
/// <param name="데미지 간격"></param>
    public void StartDamageOverTime(float duration, float tickInterval)
    {
        // 1. 이미 DOT가 진행 중이라면 기존 Coroutine을 중지
        if (dotCoroutine != null)
        {
            StopCoroutine(dotCoroutine);
        }

        // 2. 새로운 DOT Coroutine 시작
        dotCoroutine = StartCoroutine(DamageOverTimeRoutine(duration, tickInterval));
        Debug.Log($"DOT 시작! {duration}초 동안 지속.");
    }

    IEnumerator DamageOverTimeRoutine(float duration, float tickInterval)
    {
        float elapsedTime = 0f;

        // 총 지속 시간 동안 반복
        while (elapsedTime < duration)
        {
            //데미지 적용
            //TakeDamage(dotDamagePerTick);

            //다음 데미지 적용까지 지정된 시간만큼 대기
            yield return new WaitForSeconds(tickInterval);

            //시간 업데이트
            elapsedTime += tickInterval;
        }
        dotCoroutine = null; // 종료 후 참조 해제
    }
}
