using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestionsAndOptionsLoader : MonoBehaviour
{
    private Text text;
    private int i = 0;
    public Text[] labelsOfToggles;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = Data.instance.questions[i];
        for (int j = 0; j < 4; j++)
        {
            labelsOfToggles[j].text = Data.instance.options[i][j];
        }
        ++i;
    }

    public void loadNextQuestion()
    {
        if (i >= Data.instance.options.Count)
        {
            Debug.Log("No question to load!");
            return;
        }

        text.text = Data.instance.questions[i];
        for (int j = 0; j < 4; j++)
        {
            labelsOfToggles[j].text = Data.instance.options[i][j];
        }
        ++i;
    }
}
