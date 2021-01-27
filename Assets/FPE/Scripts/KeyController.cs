using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>鍵を使うスクリプト</summary>
public class KeyController : MonoBehaviour
{
    /// <summary>照準</summary>
    [SerializeField] Image m_crosshairUi = null;
    /// <summary>LineRenderer 兼 Line の出発点</summary>
    [SerializeField] LineRenderer m_line = null;
    /// <summary>鍵を使える距離</summary>
    [SerializeField] float m_useRange = 2.5f;
    /// <summary>当たるレイヤー</summary>
    [SerializeField] LayerMask m_layerMask = 0;

    /// <summary>錠のレイヤー</summary>
    [SerializeField] LayerMask m_lockLayerMask = 8;

    [Range(0, 4)] public int m_keyNumber = 0;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // カメラから照準に向かって Ray を飛ばし、何かに当たっているか調べる
        Ray ray = Camera.main.ScreenPointToRay(m_crosshairUi.rectTransform.position);
        RaycastHit hit;
        Vector3 hitPosition = m_line.transform.position + m_line.transform.forward * m_useRange;  // hitPosition は Ray が当たった場所。Line の終点となる。何にも当たっていない時は Muzzle から射程距離だけ前方にする。
        GameObject hitObject = null;    // Ray が当たったオブジェクト

        // Ray が何かに当たったか・当たっていないかで処理を分ける        
        if (Physics.Raycast(ray, out hit, m_useRange, m_lockLayerMask))
        {
            hitPosition = hit.point;    // Ray が当たった場所
            hitObject = hit.collider.gameObject;    // Ray が洗ったオブジェクト
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (hitObject)//錠がある？
            {
                Debug.Log("鍵を使った");
                KeyUse(hitObject);
            }
            else
            {
                Debug.Log("鍵を使う対象が無い");
            }
        }
    }
    /// <summary>錠が見つかった時///</summary>
    /// <param name="hitObject"></param>
    void KeyUse(GameObject hitObject)
    {
        var lockObject = hitObject.GetComponent<LockController>();
        if (lockObject)
        {
            lockObject.UnLockJudge(m_keyNumber);
        }
    }
}
