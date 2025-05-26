using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject learnMenu;

    [SerializeField] Button controlsButton;
    [SerializeField] Button returnButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlsButton.onClick.AddListener(EnableLearnPage);
        returnButton.onClick.AddListener(EnableStartPage);
    }

    void EnableStartPage()
    {
        mainMenu.SetActive(true);
        learnMenu.SetActive(false);
    }
    void EnableLearnPage()
    {
        mainMenu.SetActive(false);
        learnMenu.SetActive(true);
    }
}
