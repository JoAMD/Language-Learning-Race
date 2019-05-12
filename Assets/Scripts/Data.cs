using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance = null;
    public List<string> questions;
    public List<string[]> options;
    public int[] answers;
    public Color orange = new Color(246f / 255f, 128f / 256f, 0f);
    public int[] user1Answer, user2Answer;

    // Start is called before the first frame update
    void Awake()
    {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //initialisation
        questions = new List<string>();
        options = new List<string[]>();
        answers = new int[100];
        user1Answer = new int[50];
        user2Answer = new int[50];

        string[] questionsAll = { "Are there any good restaurants around here? Yes, ______ the highway.",
                                "What does your sister do? ______",
                                "Click the best synonym for plenty:",
                                "Click the best synonym for haul:",
                                "Click the best synonym for random:",
                                "",
                                "",
                                "",
                                "",
                                "",
                                ""};

        questions.AddRange(questionsAll);

        string[] optionArray = { "are some on", "there are many on", "are there many on", "there are some to", "there are a little near" };

        options.Add(optionArray);
        answers[0] = 1;

        optionArray = new string[] { "She work in a factory.", "She teaches to children English.", "My sister writes books.", "Works at the school.", "She works to a bank." };
        options.Add(optionArray);
        answers[1] = 2;

        optionArray = new string[] { "enough",
                                    "amount",
                                    "load",
                                    "money"};
        options.Add(optionArray);
        answers[2] = 0;

        optionArray = new string[] { "explore",
                                    "achieve",
                                    "drag",
                                    "release"};
        options.Add(optionArray);
        answers[3] = 2;

        optionArray = new string[] { "relevant",
                                    "secure",
                                    "chance",
                                    "uninteresting"};
        options.Add(optionArray);
        answers[4] = 2;

        for (int i = 0; i < options.Count; i++)
        {
            for (int j = 0; j < options[i].Length; j++)
            {
                Debug.Log(options[i][j]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
