using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;
    bool waiting = false;
    
    public Text winT;
    public Text loseT;
    public Text playagainT;

    public KeyCode r;
    public KeyCode esc;

    float waitLength = 2f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(esc))
        {
            SceneManager.LoadScene("Menu");
        }

        if (win || lose || waiting)
        {
            if (win == true)
            {
                winT.text = "YOU WIN ! :)";
            }
            else if (lose == true)
            {
                loseT.text = "you lose :(";
            }
            
            if (waitLength > 0f)
            {
                waitLength -= Time.deltaTime;
            }
            else 
            {
                win = false;
                lose = false;
                waiting = true;
                winT.text = "";
                loseT.text = "";
                playagainT.text = "Play again? press R\nor press Esc to exit to menu";

                if (Input.GetKeyDown(r))
                {
                    SceneManager.LoadScene("Level1");
                }
            }

        }
    }
}
