using UnityEngine;
using System.Collections;

public class ScriptableObjectPerformanceTest : ScriptableObject {

    public double HeavyCalc() {
        return Mathf.Cos(Time.deltaTime) * Mathf.Sin(Time.deltaTime) / 99 * Mathf.PI * Mathf.Pow(Time.deltaTime,8);
    }
}
