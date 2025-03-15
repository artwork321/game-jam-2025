using UnityEngine;


[CreateAssetMenu(fileName = "CombineResult", menuName = "ScriptableObjects/CombineResult")]
public class CombineResult : ScriptableObject
{
    public string combinationResultName;
    public Sprite newLook;
    public Combination combination;
    public bool isDiscovered;
    public string description;
    
    public bool Discovered() {
        if (!isDiscovered) {
            isDiscovered = true;
            return false;
        }

        return true;
    }

    public void ResetDiscovered() {
        isDiscovered = false;
    }
}
