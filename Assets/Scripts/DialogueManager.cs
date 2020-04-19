using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

    DialogueParser parser;

    public string dialogue, characterName;
    public int lineNum;
    int pose;
    string position;
    string[] options;
    public bool playerTalking;
    List<Button> buttons = new List<Button> ();

    public Text dialogueBox;
    public Text nameBox;
    public GameObject rightSpeaker;
    public GameObject leftSpeaker;

    // Use this for initialization
    void Start () {
        dialogue = "";
        characterName = "";
        pose = 0;
        position = "L";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        lineNum = 0;
    }


    private void OnRenderObject() {
        ShowDialogue();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0) && playerTalking == false) {
            ShowDialogue();
            lineNum++;
        }

        UpdateUI ();
    }

    public void ShowDialogue() {
        ResetImages ();
        ParseLine ();
    }

    void UpdateUI() {
        dialogueBox.text = dialogue;
        nameBox.text = characterName;
    }

    void ParseLine() {
        characterName = parser.GetName (lineNum);
        dialogue = parser.GetContent (lineNum);
        pose = parser.GetPose (lineNum);
        position = parser.GetPosition (lineNum);
        DisplayImages();
    }

    void ResetImages() {
        rightSpeaker.GetComponent<Image>().color = Color.clear;
        leftSpeaker.GetComponent<Image>().color = Color.clear;
    }

    void DisplayImages() {
        if (characterName != "") {
            GameObject character = GameObject.Find (characterName);
            Image currImg = (position == "R" ? rightSpeaker : leftSpeaker).GetComponent<Image>();
            currImg.sprite = character.GetComponent<Character>().characterPoses[pose];
            currImg.color = Color.white;
        }
    }

}
