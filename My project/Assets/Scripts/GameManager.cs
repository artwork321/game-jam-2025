using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Combination currentCombination;

    private static GameManager instance;

    public EvolveResult database;

    public GameObject bubble;

    private Coroutine co_fadingIn;

    public ResultPanel resultPanel;

    public CollectionManager collectionManager;

    public int numberDiscover = 0;

    public GameObject endingPanel;

    public bool isEnding;

    public void Awake() {
        
        if(instance != null) {
            Debug.Log("Game Manager already exists.");
        }
        instance = this;
        currentCombination = new Combination();

        collectionManager.database = database;
        collectionManager.resultPanel = resultPanel;
    }

    public static GameManager GetInstance() {
        return instance;
    }


    public void Evolve()
    {
        string resultName = null;

        if (currentCombination.atmostphere == null || currentCombination.gravity == null 
            || currentCombination.temperature == null || currentCombination.water == null || currentCombination.temperature == ""
            || (currentCombination.temperature == "Remove all skin" && currentCombination.atmostphere == "Efficient Blood Cells") 
            || (currentCombination.water == "Transport water" && currentCombination.atmostphere == "Bigger Lung") ||
            currentCombination.water == "Drink it!")
        {
            resultName = "Dead";
        }
        else if (currentCombination.atmostphere == "No Lung")
        {
            resultName = "Plant";
        }
        else if (currentCombination.gravity.Trim() == "No arms and legs")
        {
            resultName = "Slime";
            
        }
        else
        {
            CombineResult result = database.GetCombinationName(currentCombination);
            ProcessResult(result);
            return;
        }

        Debug.Log(resultName);

        // If resultName is set, get the result and process it
        ProcessResult(database.GetCombination(resultName));
    }

    private void ProcessResult(CombineResult result)
    {
        if (result == null) return;

        if (!result.Discovered())
        {
            numberDiscover++;
        }

        // Display Result
        resultPanel.gameObject.SetActive(true);
        resultPanel.DisplayEvolveResult(result);

        // Update collections
        collectionManager.ShowImageOfSlot(result.combinationResultName);
    }

    public void isEndGame() {
        Debug.Log(numberDiscover);

        if (numberDiscover == 11 && !isEnding) {
            endingPanel.SetActive(true);
            isEnding = true;
        }
    }

    public void UpdateCombination(string type, string value) {
        if (type == "atmostphere") {
            currentCombination.UpdateAtmostphere(value);
        }
        else if (type == "gravity") {
            currentCombination.UpdateGravity(value);
        }
        else if (type == "temperature") {
            currentCombination.UpdateTemp(value);
        }
        else if (type == "water"){
            currentCombination.UpdateWater(value);
        }
    }

    public Combination GetCurrentCombination() {
        return currentCombination;
    }

    public string GetValueCombination(string type) {
        if (type == "atmostphere") {
            return currentCombination.atmostphere;
        }
        else if (type == "gravity") {
            return currentCombination.gravity;
        }
        else if (type == "temperature") {
            return currentCombination.temperature;
        }
        else if (type == "water"){
            return currentCombination.water;
        }
        return null;
    }

    public void UpdateResponse(string response) {
        TextMeshProUGUI content = bubble.GetComponentInChildren<TextMeshProUGUI>();
        content.text = response;

        FadingInBubble();
    }

    public void FadingInBubble(){   

        if (co_fadingIn != null) {
            return;
        }

        co_fadingIn = StartCoroutine(Fading(1f));
    }


    public IEnumerator Fading(float targetOpacity)
    {   
        Image imageComponent = bubble.GetComponent<Image>();
        
        TextMeshProUGUI content = bubble.GetComponentInChildren<TextMeshProUGUI>();

        Color c = content.color;
        Color i = imageComponent.color;

        float originalAlpha = c.a;
        float timeElapsed = 0f;

        // Fade over the given duration
        while (timeElapsed < 0.5f)
        {
            // Calculate the new alpha
            c.a = Mathf.Lerp(originalAlpha, targetOpacity, timeElapsed / 0.5f);
            i.a = c.a;

            imageComponent.color = i;
            content.color = c;
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        c.a = targetOpacity;
        i.a = c.a;
        imageComponent.color = i;
        content.color = c;

        co_fadingIn = null;

        yield return new WaitForSeconds(3f);

        // Make it dissapear after 2 seconds
        c.a = 0f;
        i.a = c.a;
        imageComponent.color = i;
        content.color = c;
    }

    public void ResetGame() {
        // Reset collection
        database.ResetDiscovered();
        collectionManager.HideImageOfSlot();
        numberDiscover = 0;
    }

}
