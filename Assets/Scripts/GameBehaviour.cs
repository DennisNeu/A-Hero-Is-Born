using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public string labelText = "Collect all four items and win your freedom!";
    public int maxIntems = 4;

    private bool showWinScreen = false;

    private bool showLossScreen = false;

    private float timeSinceStart = 0f;
    private float elapsedTime = 0f;
    private float bestTime = 0;

    private int _itemsCollected = 0;
    public int Items {
        get {
            return _itemsCollected;
        }

        set {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= maxIntems) {
                labelText = "You have found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            } else {
                labelText = "Item found, only " + (maxIntems - _itemsCollected) + " to go!";
            }
        }
    }
    private int _playerHP = 1;
    public int HP {
        get {
            return _playerHP;
        }

        set {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0) {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            } else {
                labelText = "Ouch... that hurt";
            }
        }
    }

    private void Start() {
        timeSinceStart = Time.time;
        if (PlayerPrefs.HasKey("bestTime")) {
            bestTime = PlayerPrefs.GetFloat("bestTime");
        }
    }

    private void Update() {
        elapsedTime = Time.time - timeSinceStart;
    }

    private void OnGUI() {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items collected: " + _itemsCollected);

        GUI.Box(new Rect(20, 80, 150, 25), string.Format("Time: {0,6:0.0} sec.", elapsedTime));

        GUI.Box(new Rect(20, 110, 150, 25), string.Format("Best time: {0,6:0.0} sec.", bestTime));

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen) {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!!")) {
                SceneManager.LoadScene(0);

                Time.timeScale = 1.0f;

                if (elapsedTime < bestTime || bestTime == 0) {
                    bestTime = elapsedTime;
                    PlayerPrefs.SetFloat("bestTime", bestTime);
                    PlayerPrefs.Save();
                }
            }
        }

        if (showLossScreen) {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose...")) {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}
