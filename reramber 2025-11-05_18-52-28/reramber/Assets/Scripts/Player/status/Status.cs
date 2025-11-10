using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "플레이어", menuName = "플레이어/플레이어 능력치")]
public class Status : ScriptableObject
{
    public int hp;                     //체력
    public int attack;                 //공격력
    public int def;                    //방어력
    public float attackSpeed;          //공격속도
    public float moveSpeed = 5f;            //이동속도
    public float jumpForce = 7f;            //점프력
    public float luck;                 //행운
    public float criticalChance;       //치명타확률
    public float criticalDamage;       //치명타데미지
}
