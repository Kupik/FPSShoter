using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;

#endif


public class MenuBar : MonoBehaviour
{


    private PlayerInput inputActions;
    private InputAction _menu;



    [Header("Menu")]
    public GameObject _menuActiv;
    public GameObject _playGame;
    public GameObject _settingGame;
    public GameObject _exitGame;
    [Header("Menu")]



    [Header("Select Setting")]
    public GameObject _volum;
    public GameObject _keyboard;
    public GameObject _gamepad;
    [Header("Select Setting")]


    [Header("Seting")]

    public GameObject _volumgameSeting;
    public GameObject _keyboardGameSeting;
    public GameObject _gamepadGameSeting;

    [Header("Seting")]


    public GameObject _closeSeting;

    private bool menuOpen = true;
   // private bool menuactive;

    // Start is called before the first frame update
    private void Awake()
    {
        _menuActiv.SetActive(false);

        inputActions = GetComponent<PlayerInput>();
        _menu = inputActions.actions["SetingOpen"];

    }

    private void OnEnable()
    {
        _menu.performed += _ => SettingActive();

        _menu.Enable();
    }

    private void OnDisable()
    {
        _menu.canceled -= _ => SettingActive();

        _menu.Disable();

    }


    private void SettingActive()
    {
        menuOpen = !menuOpen;
        _menuActiv.SetActive(menuOpen);

        if (menuOpen)
        {

            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;


        }
        else
        {

            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }

    }


    public void ContinuePlay()
    {
        
        _menuActiv.SetActive(!menuOpen);
    }

    public void OpenSeting()
    {

        if (_settingGame != null)
        {
            _settingGame.SetActive(true);
            _playGame.SetActive(false);
            _exitGame.SetActive(false);
        }
    }

    public void ExitGame()
    {
        
        Application.Quit();
        Debug.Log("inchis");
    }

    public void CloseSeting()
    {


        _settingGame.SetActive(false);

        _playGame.SetActive(true);
        _exitGame.SetActive(true);
        SettingActive();


        menuOpen = false;

    }


 

    public void Volum()
    {
        _volum.SetActive(true);
        _keyboard.SetActive(true);
        _gamepad.SetActive(true);

        _volumgameSeting.SetActive(true);
        _keyboardGameSeting.SetActive(false);
        _gamepadGameSeting.SetActive(false);

    }
    public void Keyboard()
    {
        _volum.SetActive(true);
        _keyboard.SetActive(true);
        _gamepad.SetActive(true);

        _volumgameSeting.SetActive(false);
        _keyboardGameSeting.SetActive(true);
        _gamepadGameSeting.SetActive(false);

    }

    public void Gamepad()
    {
        _volum.SetActive(true);
        _keyboard.SetActive(true);
        _gamepad.SetActive(true);

        _volumgameSeting.SetActive(false);
        _gamepadGameSeting.SetActive(true);
        _keyboardGameSeting.SetActive(false);

    }

    public void Graphic()
    {
        _volum.SetActive(true);
        _keyboard.SetActive(true);
        _gamepad.SetActive(true);

        _volumgameSeting.SetActive(false);
      
        _keyboardGameSeting.SetActive(false);
        _gamepadGameSeting.SetActive(false);
     


    }

}