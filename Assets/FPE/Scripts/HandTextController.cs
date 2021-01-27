using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTextController : MonoBehaviour
{
    Text m_text;
    GameObject m_player;
    KeyController m_keyController;
    Color num1Color = new Color(125, 81, 1, 255);
    Color num2Color = new Color(212, 212, 212, 255);
    Color num3Color = new Color(255, 194, 0, 255);
    Color emptyColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_keyController = m_player.GetComponent<KeyController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_keyController.m_keyNumber)
        {
            case 1:
                m_text.color = num1Color;
                m_text.text = ("鍵");
                break;
            case 2:
                m_text.color = num2Color;
                m_text.text = ("鍵");
                break;
            case 3:
                m_text.color = num3Color;
                m_text.text = ("鍵");
                break;
            case 0:
                m_text.color = emptyColor;
                m_text.text = ("素手");
                break;
        }
    }
}
