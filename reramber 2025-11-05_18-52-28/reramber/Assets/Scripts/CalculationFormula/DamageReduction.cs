using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// 피해감소율
/// </summary>
public partial class CalculationFormulas : MonoBehaviour
{
    float def;
    public float DamageReduction()
    {
        return 100 + def / def;
    }
}
