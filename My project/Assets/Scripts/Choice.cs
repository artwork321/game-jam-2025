using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Choice : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI text;
    private string type;
    public bool isSelect => GameManager.GetInstance().GetValueCombination(type) == text.text;
    public string response;
    

    public void Awake() {
        button = GetComponent<Button>();
        text = button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void changeTextColorWhenEnter() {
        UpdateColor();
    }

    public void changeTextColorWhenExit() {
        if (!isSelect) 
            RemoveTextColor();
    }

    public void OnClick() {
        GameManager.GetInstance().UpdateCombination(type, text.text);
        Debug.Log("Choose: " + text.text + " of type " + type);

        transform.parent.GetComponent<ChoicePanel>().UpdateChoice(button);
        UpdateColor();

        GameManager.GetInstance().UpdateResponse(response);
    }

    public void UpdateType(string newType) {
        type = newType;
    }

    public void UpdateColor() {
        text.color = new Color(1f, 1f, 0.8f);
    }

    public void RemoveTextColor() {
        text.color = new Color(1f, 1f, 1f);
    }

}
