using UnityEngine;

[CreateAssetMenu(fileName = "new float value", menuName = "SO Variables/Int Value")]
public sealed class IntValue : ScriptableObject
{
    [Header("Default value")]
    public int defaultIntValue;
    [Header("Runtime value")]
    public int intValue;

    private void OnEnable()
    {
        intValue = defaultIntValue;
    }
}
