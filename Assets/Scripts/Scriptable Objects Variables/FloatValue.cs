using UnityEngine;

[CreateAssetMenu(fileName = "new float value", menuName = "SO Variables/Float Value")]
public sealed class FloatValue : ScriptableObject
{
    [Header("Default value")]
    public float defaultFloatValue;
    [Header("Runtime value")]
    public float floatValue;

    private void OnEnable()
    {
        floatValue = defaultFloatValue;
    }
}
