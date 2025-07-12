using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseMenu;
    public GameObject Canvas;
    public GameObject Camera;
    public Button MainMenubutton;
    public Button Resumebutton;
    public SpriteRenderer penguinSpriteRenderer;

    private bool cachedFlipX = false;

    void Awake()
    {
        Canvas.SetActive(true);
    }

    void Start()
    {
        MainMenubutton.onClick.AddListener(MainMenu);
        Resumebutton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsGamePaused)
                Pause();
            else
                Resume();
        }
    }

    void MainMenu()
    {
        
    }

    void Pause()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (penguinSpriteRenderer != null)
        {
            cachedFlipX = penguinSpriteRenderer.flipX;
        }

        IsGamePaused = true;
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        IsGamePaused = false;
    }
}
