using System;
using UnityEngine;
using UnityEngine.UI;

namespace Oqupie
{
    public class Example : MonoBehaviour
    {
        public InputField inputWebViewUrl = null;
        public Button buttonGetAppInfo = null;
        public Button buttonOpenWebView = null;
        public Text textOutput = null;

        // Use this for initialization
        private void Start()
        {
            this.buttonGetAppInfo.onClick.AddListener(OnClickGetAppInfo);
            this.buttonOpenWebView.onClick.AddListener(OnClickOpenWebView);

            this.inputWebViewUrl.text = "https://oqtest.oqupie.com/portals/finder";
        }

        private void OnClickGetAppInfo()
        {
            var appInfo = GetAppInfo();
            WriteLine(appInfo.ToQueryString());
        }

        private void OnClickOpenWebView()
        {
            var appInfo = GetAppInfo();
            OqupieManager.Instance.OpenWebView(this.inputWebViewUrl.text, appInfo, true, "고객센터", new Color32(127, 115, 231, 255));
        }

        private void WriteLine(string msg)
        {
            this.textOutput.text = msg + Environment.NewLine;
        }

        private AppInfo GetAppInfo()
        {
            var appInfo = OqupieManager.Instance.GetAppInfo();
            appInfo.AddInfo("userName", "Michael");
            appInfo.AddInfo("userId", "unitymania");
            appInfo.AddInfo("applicationLanguage", "English");
            appInfo.AddInfo("userEmail", "example@onionfive.io");
            appInfo.AddInfo("access_key", "2190ffccd8dbb478");
            appInfo.AddInfo("secret_key", "dde1cc31a14524bf903b2b1e71a8afde");
            appInfo.AddInfo("brand_key1", "ko");
            appInfo.AddInfo("brand_key2", "goodgame");
            appInfo.AddInfo("brand_key3", "asia");
            appInfo.AddInfo("게임엔진", "유니티");
            appInfo.AddInfo("vip_code", "VVIP");            
            return appInfo;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
