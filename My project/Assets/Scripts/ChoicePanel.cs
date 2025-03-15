using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ChoicePanel : MonoBehaviour
{
    [SerializeField] private List<Button> choiceButtons;
    [SerializeField] private TextMeshProUGUI detail;

    public void Awake() {
        detail.text = "Choose human body part to evolve!";
    }


    public void ShowOptions(List<string> optionText, List<string> responses, string type, string detail) {
        int i = 0;
        this.detail.text = detail;
        

        foreach(Button choice in choiceButtons) {
            choice.gameObject.SetActive(true);
            choice.GetComponent<Choice>().UpdateType(type);
            TextMeshProUGUI buttonText = choice.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = optionText[i];
            choice.GetComponent<Choice>().response = responses[i++];

            // Update color of buttons
            if(choice.GetComponent<Choice>().isSelect) {
                Debug.Log(GameManager.GetInstance().GetValueCombination(type));
                Debug.Log(type);
                choice.GetComponent<Choice>().UpdateColor();
            }
            else {
                choice.GetComponent<Choice>().RemoveTextColor();
            }
        }
    }

    public void UpdateChoice(Button selectButton) {
        foreach(Button choice in choiceButtons) {
            if(choice != selectButton) {
                choice.gameObject.GetComponent<Choice>().RemoveTextColor();
            }
        }
    }
}
