using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//put this enum here becasue it is used to check what state the game is in
public enum GameState
{
    Menu,
    buildState,
    playState,
}


//manager of the scenes
//deals with change of UI when scene switching
public class Scene_Manager : MonoBehaviour
{
    public GameObject garage_Panel;
    public GameObject play_Panel;

    public GameState stateOfGame;

    public static Scene_Manager S;

    //i have never seen this format before but its awesome i love it and im going to use it all the time for Awake
    private void Awake() => S = this;

    public void loadFlyScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        stateOfGame = GameState.playState;
        garage_Panel.SetActive(false);
        play_Panel.SetActive(true);
    }
}
