using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static int asteroid;
    public static float count;
    public static bool status = true;

    public float second;
    public float record;

    private float gameTime;

    private bool start = false;
    private bool newrecord = false;

    public Text over;
    public Text timer;
    public Text counter;
    public Text bestrecord;
    public Text asteroids;

    // Start is called before the first frame update
    void Start()
    {
        record = (float)PlayerPrefs.GetInt("GameRocord", 0); //Загружаем рекорд.

        bestrecord.text = "Текущий рекорд: " + $"{record}";

        count = 0;
        second = 0.0f;
        asteroid = 0;

        Time.timeScale = 0;

        over.text = "Для начала игры нажмите любую клавишу.";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) 
        {
            start = true;
            Time.timeScale = 1;
            over.text = "";
        }

        if (start) 
        {
            Game();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Game() 
    {
        timer.text = "Время игры: " + $"{second}";
        asteroids.text = "Астероиды: " + $"{asteroid}";

        gameTime += 1 * Time.deltaTime;

        if (gameTime >= 1)
        {
            second += 1;
            gameTime = 0;

            if (RoadMove.acceleration) //Если игрок под ускорением +2 очка если нет +1.
            {
                count += 2;
            }
            else
            {
                count += 1;
            }
        }

        if (count > record)  //Если текущий счёт больше рекорда, заменяем рекорд на текущий счёт.
        {
            newrecord = true;
            record = count;
            bestrecord.text = "Ваш рекорд: " + $"{record}";
        }

        if (!status)  //Если столкнулись с астероидом.
        {
            if (newrecord)
            {
                over.text = "Конец игры! Поздравляю вы установили новый рекорд! Ваш счёт: " + count + " , для выхода нажмите ESC для повтора нажмите Enter.";
            }
            else 
            {
                over.text = "Конец игры, Ваш счёт: " + count + " , для выхода нажмите ESC для повтора нажмите Enter.";
            }
            
            PlayerPrefs.SetInt("GameRocord", (int)record); //Сохраняем рекорд.
            PlayerPrefs.Save();

            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SampleScene");
                start = false;
                status = true;
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Application.Quit();
            }
        }

        counter.text = "Счёт игры: " + $"{count}";
    }

}
