using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
        Debug.Log("Level Load Requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Game Finished");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        //  Reset the number of breakable bricks in the scene to 0
        Brick.breakableCount = 0;

        //  Load the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        //  If the player has destroyed all of the breakable bricks in the scene
        //  then we move to the next scene
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
