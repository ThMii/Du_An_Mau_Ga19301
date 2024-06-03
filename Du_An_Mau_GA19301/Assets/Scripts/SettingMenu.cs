using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    public class SettingMenu : MonoBehaviour
    {
        [SerializeField] GameObject settingMenu;
        public void Setting()
        {
            settingMenu.SetActive(true);
            Time.timeScale = 0;
        }
        public void X()
        {
            settingMenu.SetActive(false);
            Time.timeScale = 1;
  
        }
    }
}

