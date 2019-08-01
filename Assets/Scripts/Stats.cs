using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
public class Stats : ScriptableObject
{
    [Tooltip("Velocidad de movimiento")]
    public int Speed;

    public int Attack;
}
