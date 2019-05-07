using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public QuestionsAndOptionsLoader questionsLoader;
    private int i = 0;
    private bool orangeIsCorrect, yellowIscorrect;
    public Sprite red, green, yellow, none;
    //public Transform redCrossMark, greenTickMark, redCrossMark1, greenTickMark1;
    public SpriteRenderer spriteRendererYellow, spriteRendererOrange, yellowIndicator, orangeIndicator;
    //private Vector3 orangePos = new Vector3(16.2f, 8.62f, 1f), yellowPos = new Vector3(-15.5f, 8.62f, 1f);
    public CarMove yellowCarMove, orangeCarMove;
    public SpriteRenderer yellowBubbleRenderer, orangeBubbleRenderer;
    public Text yellowBubbleText, orangeBubbleText;

    public void submit()
    {
        //reset alpha values to 0 so that objects can be faded in immediately
        spriteRendererOrange.color = new Color(spriteRendererOrange.color.r, spriteRendererOrange.color.g, spriteRendererOrange.color.b, 0);
        spriteRendererYellow.color = new Color(spriteRendererYellow.color.r, spriteRendererYellow.color.g, spriteRendererYellow.color.b, 0);
        yellowBubbleRenderer.color = new Color(yellowBubbleRenderer.color.r, yellowBubbleRenderer.color.g, yellowBubbleRenderer.color.b, 0);
        orangeBubbleRenderer.color = new Color(orangeBubbleRenderer.color.r, orangeBubbleRenderer.color.g, orangeBubbleRenderer.color.b, 0);
        yellowBubbleText.color = new Color(yellowBubbleText.color.r, yellowBubbleText.color.g, yellowBubbleText.color.b, 0);
        orangeBubbleText.color = new Color(orangeBubbleText.color.r, orangeBubbleText.color.g, orangeBubbleText.color.b, 0);

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
                    //Setting bubble texts from Label on toggle which isOn
                    if(i % 2 == 0)
                    {
                        orangeBubbleText.text = toggle.GetComponentInChildren<Text>().text;
                    }
                    else
                    {
                        yellowBubbleText.text = toggle.GetComponentInChildren<Text>().text;
                    }

                    toggle.isOn = false; //find a workaround!!!!!!!!!!!!!!!!!!!!!!!!!$$$$$$$$$$$$$
                    if (toggle.name.Equals("Toggle" + (Data.instance.answers[i / 2] + 1).ToString())) // == Data.instance.options[i][Data.instance.answers[i]])
                    {
                        if (i % 2 == 0)
                        {
                            orangeIsCorrect = true;
                            //orangeBubbleText.color = Color.green;
                        }
                        else
                        {
                            yellowIscorrect = true;
                            //yellowBubbleText.color = Color.green;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            orangeIsCorrect = false;
                            //orangeBubbleText.color = Color.red;
                        }
                        else
                        {
                            yellowIscorrect = false;
                            //yellowBubbleText.color = Color.red;
                        }
                    }
                }
                toggleEnum.MoveNext();
            }
            if(i % 2 == 0)
            {
                gameObject.GetComponent<Image>().color = Color.yellow;
                yellowIndicator.color = Color.yellow;
                orangeIndicator.color = Color.white;
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
                    orangeCarMove.orange = true;
                    yellowCarMove.orange = true;
                    orangeCarMove.startTime = Time.time;
                    //orangeCarMove.moveFront();
                }
                else
                {
                    Debug.Log("Orange is wrong!");
                    spriteRendererOrange.sprite = red;
                    orangeCarMove.orange = false;
                    yellowCarMove.orange = false;
                    orangeCarMove.startTime = Time.time;/////////////
                    //redCrossMark.position = orangePos;
                }
                if (yellowIscorrect)
                {
                    Debug.Log("Yellow is correct!");
                    spriteRendererYellow.sprite = green;
                    //greenTickMark1.position = yellowPos;
                    //yellowCarMove.moveFront();
                    yellowCarMove.startTime = Time.time;
                    orangeCarMove.yellow = true;
                    yellowCarMove.yellow = true;
                }
                else
                {
                    Debug.Log("Yellow is wrong!");
                    spriteRendererYellow.sprite = red;
                    orangeCarMove.yellow = false;
                    yellowCarMove.yellow = false;
                    yellowCarMove.startTime = Time.time;//////////
                    //redCrossMark1.position = yellowPos;
                }

                int fadeDuration = 1, waitTime = 3;
                //Fade in immediately
                IEnumerator coroutine = FadeTo(spriteRendererOrange, 1, fadeDuration, 0);
                StartCoroutine(coroutine);
                coroutine = FadeTo(spriteRendererYellow, 1, fadeDuration, 0);
                StartCoroutine(coroutine);

                coroutine = FadeTextTo(yellowBubbleText, 1, fadeDuration, 0);
                StartCoroutine(coroutine);
                coroutine = FadeTo(yellowBubbleRenderer, 1, fadeDuration, 0);
                StartCoroutine(coroutine);
                coroutine = FadeTextTo(orangeBubbleText, 1, fadeDuration, 0);
                StartCoroutine(coroutine);
                coroutine = FadeTo(orangeBubbleRenderer, 1, fadeDuration, 0);
                StartCoroutine(coroutine);

                //Fade out after 3 seconds
                coroutine = FadeTo(spriteRendererOrange, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);
                coroutine = FadeTo(spriteRendererYellow, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);

                coroutine = FadeTextTo(yellowBubbleText, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);
                coroutine = FadeTo(yellowBubbleRenderer, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);
                coroutine = FadeTextTo(orangeBubbleText, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);
                coroutine = FadeTo(orangeBubbleRenderer, 0, fadeDuration, waitTime);
                StartCoroutine(coroutine);



                questionsLoader.loadNextQuestion();
            }

            i++;
        }
    }

    // Define an enumerator to perform our fading.
    // Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
    // and the number of seconds to fade over.
    IEnumerator FadeTo(SpriteRenderer spriteRenderer, float targetOpacity, float duration, float afterTime)
    {

        yield return new WaitForSeconds(afterTime);

        // Cache the current color of the material, and its initiql opacity.
        Color color = spriteRenderer.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            spriteRenderer.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }

    IEnumerator FadeTextTo(Text text, float targetOpacity, float duration, float afterTime)
    {

        yield return new WaitForSeconds(afterTime);

        // Cache the current color of the material, and its initiql opacity.
        Color color = text.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            text.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }

}
