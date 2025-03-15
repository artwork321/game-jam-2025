using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    public Image resultImage;
    public GameObject smokeEffect;
    public TextMeshProUGUI resultName;
    public Animator smokeAnimator;
    public GameObject star;
    public Button exitButton;

    public void DisplayEvolveResult(CombineResult result) {
        AudioManager.GetInstance().PlaySFX("Appear");
        StartCoroutine(ShowEvolveResult(result));        
    }

    public IEnumerator ShowEvolveResult(CombineResult result) {

        smokeEffect.SetActive(true);
        star.SetActive(true);
        resultImage.sprite = result.newLook;
        resultName.text = result.description;

        smokeAnimator.Play("bomb", 0);

        Animator[] starObjectAnimators = star.GetComponentsInChildren<Animator>();

        foreach(Animator starAnimator in starObjectAnimators) {
            starAnimator.Play("flash", 0);
        }
        

        yield return new WaitForSeconds(0.55f);
        smokeEffect.SetActive(false);

        yield return new WaitForSeconds(2f);
        exitButton.gameObject.SetActive(true);
    }

    public void Exit() {
        
        resultImage.sprite = null;
        resultName.text = "";

        Animator[] starObjectAnimators = star.GetComponentsInChildren<Animator>();
        star.SetActive(false);

        exitButton.gameObject.SetActive(false);
        gameObject.SetActive(false);

        GameManager.GetInstance().isEndGame();
    }
}
