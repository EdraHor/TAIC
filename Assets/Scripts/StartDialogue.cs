using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class StartDialogue : MonoBehaviour
{
    public NPCConversation TestConversation;
    public NPCConversation TestConversationTwo;
    private bool ItWas = false;

    //ItWas == false
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (ItWas == false)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                ConversationManager.Instance.StartConversation(TestConversation);
                ItWas = true;
            }
            else
            {
                ConversationManager.Instance.StartConversation(TestConversationTwo);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        ConversationManager.Instance.EndConversation();
    }
    }
