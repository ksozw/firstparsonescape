using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    /// <summary>作動させるオブジェクト/// </summary>
    [SerializeField] GameObject m_gimmickObject = null;
    /// <summary>錠のランク/// </summary>
    [SerializeField, Range(0, 4)] int m_lockNumber = 0;


    GimmickBase m_gimmickBase;//static
    void Start()
    {
        if (m_gimmickObject)
        {
            m_gimmickBase = m_gimmickObject.GetComponent<GimmickBase>();
        }
        else
        {
            Debug.LogError("対応ギミックがありません");
        }
    }

    /// <summary> </summary>
    /// <param name="m_keyNumber">鍵のランク</param>
    public void UnLockJudge(int m_keyNumber)
    {
        if (m_keyNumber >= m_lockNumber)
        {
            m_gimmickBase.Action();
        }
        else
        {
            Debug.Log("鍵のランクが足りないようだ");
        }
    }
}
