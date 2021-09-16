using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private Text textComponent;
    [SerializeField]
    private float textSpeed; // the speed at which each character in a sentence should appear on screen
    [SerializeField]
    private string[] lines; // array of sentences in the conversation
    [SerializeField]
    private GameObject[] persons;
    private int index; // for referring the sentences in the lines array
    public static Conversation instance;
    public bool isDialogueOver;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        textComponent.text = string.Empty; 
        StartDialogue();
        persons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                if(index%2 == 0)
                {
                    persons[0].SetActive(false);
                    persons[1].SetActive(true);
                }
                else
                {
                    persons[0].SetActive(true);
                    persons[1].SetActive(false);
                }
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        
        //display each character one by one with some speed
        foreach(char c in lines[index].ToCharArray()) // makes array into charater array
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        /*
         * displaying a line in the lines array
         * if no line is remaning then disable the conversation panel
         */
        if(index<lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            isDialogueOver = true;
        }
    }
}
