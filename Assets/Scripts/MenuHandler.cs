using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject learnMenu;

    [SerializeField] Button controlsButton;
    [SerializeField] Button returnButton;

    private string buttonClick = "ui-click";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlsButton.onClick.AddListener(EnableLearnPage);
        returnButton.onClick.AddListener(EnableStartPage);

    }

    void EnableStartPage()
    {
        AudioManager.Instance.Play(buttonClick);
        mainMenu.SetActive(true);
        learnMenu.SetActive(false);
    }
    void EnableLearnPage()
    {
        AudioManager.Instance.Play(buttonClick);
        mainMenu.SetActive(false);
        learnMenu.SetActive(true);
    }
}
