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
    public AudioSource audioSource;
    public AudioClip customClip;
    private AudioSource _audio;

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
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = customClip;
        audioSource.Play(); 
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

}
