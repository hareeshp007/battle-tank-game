
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI AchevementsForShooting;
    [SerializeField]
    private TextMeshProUGUI PlayerHealthText;
    [SerializeField]
    private TextMeshProUGUI EnemiesCountText;

    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject InGame;
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject GameWon;

    [SerializeField]
    private List<string> Achevements;
    [SerializeField]
    private int Duration = 3;
    [SerializeField]
    private int EnemyCount;
    [SerializeField]
    private int MaxLevel;
    [SerializeField]
    private int CurrLevel;

    private Coroutine AchevementDisplay ;
    [SerializeField]
    private string mainMenuScene;

    private void Start()
    {
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        AchevementsForShooting.enabled=false;
        TankView.AchevementsUnlock += UnlockAchements;
        MainMenu.SetActive(false);
        GameWon.SetActive(false);
        InGame.SetActive(true);
        PauseMenu.SetActive(false);
    }

    private void UnlockAchements(int obj)
    {
        switch (obj)
        {
            case 10:
                AchevementsForShooting.text = Achevements[0];
                break;
            case 25:
                AchevementsForShooting.text = Achevements[1];
                break;
            case 50:
                AchevementsForShooting.text = Achevements[2];
                break;
        }
        
        AchevementDisplay =StartCoroutine(AchevementShow(Duration));
    }

    private IEnumerator AchevementShow(int duration)
    {
        AchevementsForShooting.enabled = true;
        yield return new WaitForSeconds(duration);
        AchevementsForShooting.enabled = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        InGame.SetActive(true);
        PauseMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        InGame.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void MainMenuActive()
    {
        Time.timeScale = 0;
        InGame.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void GameWonMenu()
    {
        Time.timeScale = 0;
        GameWon.SetActive(true);
        InGame.SetActive(false);
    }
    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(mainMenuScene);
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex); 
    }
    public void GUIupdateHealth(int health)
    {
        PlayerHealthText.text = "Health :" + health;
    }
    public void GUIupdateEnemies(int enemies)
    {
        EnemyCount=enemies;
        EnemiesCountText.text = "Enemies :" + EnemyCount;
    }
    public void GUIEnemyDied()
    {
        if (EnemyCount > 0)
        {
            EnemyCount-=1;

            EnemiesCountText.text = "Enemies :" + EnemyCount;
        }
        if (EnemyCount <= 0)
        {
            LevelManeger.Instance.MarkCurrentLevelCompleted();
            GameWonMenu();
        }
        
    }
    public void NextLevel()
    {
       LevelManeger.Instance.LoadNextLevel();
        
    }
}
