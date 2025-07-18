using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelsMenu;
    public GameObject Canvas;
    public GameObject Camera;
    public Button PlayButton;
    public Button ExitButton;
    public Button TutorialButton;
    public Button Lvl1Button;
    public Button Lvl2Button;
    public Button Lvl3Button;
    public SpriteRenderer penguinSpriteRenderer;

    void Awake()
    {
        Canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Start()
    {
        PlayButton.onClick.AddListener(Play);
        ExitButton.onClick.AddListener(Exit);
        // TutorialButton.onClick.AddListener(Tutorial);
        // Lvl1Button.onClick.AddListener(Lvl1);
        // Lvl2Button.onClick.AddListener(Lvl2);
        // Lvl3Button.onClick.AddListener(Lvl3);
    }
    public void Play()
    {
        MainMenu.SetActive(false);
        LevelsMenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    // public void Tutorial()
    // {
    //     SceneManager.LoadScene("Tutorial");
    // }
    // public void Lvl1()
    // {
    //     SceneManager.LoadScene("LVL1");
    // }
    // public void Lvl2()
    // {
    //     SceneManager.LoadScene("LVL2");
    // }
    // public void Lvl3()
    // {
    //     SceneManager.LoadScene("LVL3");
    // }
}
