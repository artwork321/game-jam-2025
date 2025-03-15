using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CollectionManager : MonoBehaviour
{
    public GameObject content;
    public ResultPanel resultPanel;
    public EvolveResult database;

    public void ShowImageOfSlot(string slotName) {
        foreach(Transform slot in content.transform) {
            if (slot.gameObject.name == slotName) {
                slot.Find("Cover").gameObject.SetActive(false);

                CombineResult result = database.GetCombination(slotName);
                AddClickListener(slot.Find("Specie").gameObject, result);
                break;
            }
        }
    }

    public void HideImageOfSlot() {
        foreach(Transform slot in content.transform) {
            slot.Find("Cover").gameObject.SetActive(true);
        }
    }

    private void AddClickListener(GameObject slot, CombineResult result) {
        EventTrigger trigger = slot.GetComponent<EventTrigger>();

        if (trigger == null) {
            trigger = slot.AddComponent<EventTrigger>();
        }
        
        trigger.triggers.Clear();

        EventTrigger.Entry entry = new EventTrigger.Entry {
            eventID = EventTriggerType.PointerClick
        };
        entry.callback.AddListener((data) => resultPanel.DisplayEvolveResult(result));

        EventTrigger.Entry activatePanelEntry = new EventTrigger.Entry {
            eventID = EventTriggerType.PointerClick
        };
        activatePanelEntry.callback.AddListener((data) => resultPanel.gameObject.SetActive(true));

        trigger.triggers.Add(activatePanelEntry);
        trigger.triggers.Add(entry);
    }

}
