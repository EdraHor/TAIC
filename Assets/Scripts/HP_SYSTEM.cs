using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP_SYSTEM : MonoBehaviour
{
    private int CurrentHP;
    public int MaxHP;
    public int HP;

    public Image[] All_HP;

    public Sprite Full_HP;
    public Sprite Empty_HP;

    void Start()
    {
        CurrentHP = HP;
    }

    void FixedUpdate()
    {
        CurrentHP = HP;

        if (HP < 1)
        {
            HP = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }

        for (int i = 0; i < All_HP.Length; i++)
        {
            if (i < CurrentHP)
            {
                All_HP[i].sprite = Full_HP;
            }
            else
            {
                All_HP[i].sprite = Empty_HP;
            }

            if (i < MaxHP)
            {
                All_HP[i].enabled = true;
            }
            else
            {
                All_HP[i].enabled = false;
            }

        }
    }
}
