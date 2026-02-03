using UnityEngine;

[CreateAssetMenu(fileName = "sample", menuName = "Scriptable Objects/sample")]
public class NewScriptableObjectScript : ScriptableObject
{
    public string characterName;
    public int maximumHP;
    public int strength;
}
