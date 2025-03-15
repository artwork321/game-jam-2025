using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyPart : MonoBehaviour
{
    private Image img;

    [SerializeField] private List<string> options;
    [SerializeField] private List<string> responses;
    public ChoicePanel choicePanel;
    [SerializeField] private string detail;

    public void Awake() {
        img = GetComponent<Image>();

        Color tempColor =  img.color;
        tempColor.a = 0f;
        img.color = tempColor;
    }

    public void OnPointerClick() {
        choicePanel.ShowOptions(options, responses, img.gameObject.name.ToLower(), detail);
    }

    public void OnPointerEnter() {
        Color tempColor =  img.color;
        tempColor.a = 0.8f;
        img.color = tempColor; 
    }

    public void OnPointerExit() {
        Color tempColor =  img.color;
        tempColor.a = 0f;
        img.color = tempColor;
    }
}
