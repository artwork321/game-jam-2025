using UnityEngine;
using System.Collections.Generic;

// Contains all possible combinations of choices
[CreateAssetMenu(fileName = "EvolveCombinationData", menuName = "ScriptableObjects/EvolveCombination")]
public class EvolveResult : ScriptableObject
{
    public List<CombineResult> listCombination;

    public CombineResult GetCombinationName(Combination other) {
        CombineResult evolveResult = listCombination.Find(x => (x.combination.atmostphere.Trim() == other.atmostphere.Trim() &&
                                                        x.combination.gravity.Trim() == other.gravity.Trim() &&
                                                        x.combination.temperature.Trim() == other.temperature.Trim() &&
                                                        x.combination.water.Trim() == other.water.Trim()));

        return evolveResult;
    }

    public CombineResult GetCombination(string name) {
        CombineResult evolveResult = listCombination.Find(x => (x.combinationResultName.Trim() == name));

        return evolveResult;
    }

    public void ResetDiscovered() {
        foreach (CombineResult result in listCombination) {
            result.ResetDiscovered();
        }
    }
}
