using UnityEngine;
using UnityEngine.UI;

public class RoadMapLoader : MonoBehaviour
{
    public Text questionText;
    public Text[] options;
    private int i = -1;
    private Color black = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1), darkGreen = new Color(0, 135f/255f, 0, 1);
    public GameObject redCrossMark, greenTickMark;
    private bool player1;

    // Start is called before the first frame update
    void Start()
    {
        nextQuestion();
    }

    public void nextQuestion()
    {

        if (i < Data.instance.questions.Count - 1)
        {
            i++;
        }

        if (i != 0)
        {
            options[Data.instance.answers[i - 1]].color = black;
            options[ (player1)? Data.instance.user1Answer[i - 1] : Data.instance.user2Answer[i - 1] ].color = black;
        }
        questionText.text = Data.instance.questions[i];
        for (int j = 0; j < 4; j++)
        {
            options[j].text = Data.instance.options[i][j];
        }

        //highlight user's answer 
        options[ (player1) ? Data.instance.user1Answer[i] : Data.instance.user2Answer[i] ].color = Color.yellow;

        //highlight correct answer
        options[Data.instance.answers[i]].color = darkGreen;

        //Giving tick or cross according to user's answer
        if ( ((player1) ? Data.instance.user1Answer[i] : Data.instance.user2Answer[i]) == Data.instance.answers[i])
        {
            Instantiate(greenTickMark);
        }
        else
        {
            Instantiate(redCrossMark);
        }
    }

    public void prevQuestion()
    {

        if (i > 0)
        {
            i--;
        }

        if (i != Data.instance.questions.Count)
        {
            options[Data.instance.answers[i + 1]].color = black;
            options[(player1) ? Data.instance.user1Answer[i + 1] : Data.instance.user2Answer[i + 1]].color = black;
        }
        questionText.text = Data.instance.questions[i];
        for (int j = 0; j < 4; j++)
        {
            options[j].text = Data.instance.options[i][j];
        }

        //highlight user's answer 
        options[(player1) ? Data.instance.user1Answer[i] : Data.instance.user2Answer[i]].color = Color.yellow;

        //highlight correct answer
        options[Data.instance.answers[i]].color = darkGreen;

        //Giving tick or cross according to user's answer
        if (((player1) ? Data.instance.user1Answer[i] : Data.instance.user2Answer[i]) == Data.instance.answers[i])
        {
            Instantiate(greenTickMark);
        }
        else
        {
            Instantiate(redCrossMark);
        }
    }

    public void playerChoose(bool player1)
    {
        this.player1 = player1;
    }

    public void firstQuestion()
    {
        options[Data.instance.answers[i]].color = black;
        options[(player1) ? Data.instance.user1Answer[i] : Data.instance.user2Answer[i]].color = black;
        i = -1;
        nextQuestion();
    }
}
