using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOTDANCEPARTY : MonoBehaviour
{
    [SerializeField]
    private GameObject m_cutsceneBot = null;

    [SerializeField]
    private GameObject m_gameBot = null;

    public void DanceTime()
    {
        m_cutsceneBot.SetActive(false);
        m_gameBot.SetActive(true);
    }

}
