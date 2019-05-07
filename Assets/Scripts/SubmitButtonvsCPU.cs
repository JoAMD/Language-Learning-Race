using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButtonvsCPU : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public QuestionsAndOptionsLoader questionsLoader;
    private int i = 0;
    private bool orangeIsCorrect, yellowIscorrect;
    public Sprite red, green, yellow, none;
    //public Transform redCrossMark, greenTickMark, redCrossMark1, greenTickMark1;
    public SpriteRenderer spriteRendererYellow, spriteRendererOrange, yellowIndicator, orangeIndicator;
    //private Vector3 orangePos = new Vector3(16.2f, 8.62f, 1f), yellowPos = new Vector3(-15.5f, 8.62f, 1f);
    public Toggle[] toggles;

    public void submit()
    {
        if (!toggleGroup.AnyTogglesOn())
        {
            Debug.Log("No option selected!");
        }
        else
        {
            var toggleEnum = toggleGroup.ActiveToggles().GetEnumerator();
            while (toggleEnum.MoveNext() == true)
            {
                Toggle toggle = toggleEnum.Current;
                if (toggle.isOn)
                {
                    toggle.isOn = false; //find a workaround!!!!!!!!!!!!!!!!!!!!!!!!!$$$$$$$$$$$$$
                    if (toggle.name.Equals("Toggle" + (Data.instance.answers[i / 2] + 1).ToString())) // == Data.instance.options[i][Data.instance.answers[i]])
                    {
                        if (i % 2 == 0)
                        {
                            orangeIsCorrect = true;
                        }
                        else
                        {
                            yellowIscorrect = true;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            orangeIsCorrect = false;
                        }
                        else
                        {
                            yellowIscorrect = false;
                        }
                    }
                }
                toggleEnum.MoveNext();
            }
            bool dontIncrememnt = false;
            if (i % 2 == 0)
            {
                gameObject.GetComponent<Image>().color = Color.yellow;
                yellowIndicator.color = Color.yellow;
                orangeIndicator.color = Color.white;
                
                ++i;

                //Select a toggle (CPU)
                toggles[Random.Range(0, 4)].isOn = true;

                //Click on submit button (CPU)
                submit();
                dontIncrememnt = true;
            }
            else
            {
                gameObject.GetComponent<Image>().color = Data.instance.orange;
                yellowIndicator.color = Color.white;
                orangeIndicator.color = Data.instance.orange;

                if (orangeIsCorrect)
                {
                    Debug.Log("Orange is correct!");
                    spriteRendererOrange.sprite = green;
                    //greenTickMark.position = orangePos;
                }
                else
                {
                    Debug.Log("Orange is wrong!");
                    spriteRendererOrange.sprite = red;
                    //redCrossMark.position = orangePos;
                }
                if (yellowIscorrect)
                {
                    Debug.Log("Yellow is correct!");
                    spriteRendererYellow.sprite = green;
                    //greenTickMark1.position = yellowPos;
                }
                else
                {
                    Debug.Log("Yellow is wrong!");
                    spriteRendererYellow.sprite = red;
                    //redCrossMark1.position = yellowPos;
                }

                questionsLoader.loadNextQuestion();
            }

            if (!dontIncrememnt)
            {
                i++;
            }
        }
    }

}
