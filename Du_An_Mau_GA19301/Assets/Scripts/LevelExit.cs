using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLv : MonoBehaviour
{
    public string tenManChoi;

    public void LoadManChoiMoi()
    {
        StartCoroutine(DelayLoadScene());
    }

    IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(tenManChoi);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadManChoiMoi();
        }
    }
}

