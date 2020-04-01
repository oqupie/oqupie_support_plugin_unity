using System;
using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace Oqupie
{
    /// <summary>
    /// 앱 정보를 검색하거나 웹뷰를 호출하는 매니저 클래스
    /// </summary>
    public class OqupieManager : MonoBehaviour
    {
#if UNITY_IOS
        // iOS Part
        [DllImport("__Internal")]
        private static extern void oqupieOpenWebView(string url, string appInfo, bool showTitleBar, string title, int red, int green, int blue);
#endif

        // Android Part
        private AndroidJavaObject oqupieManagerAOS = null;

        private static OqupieManager instance = null;
        public static OqupieManager Instance
        {
            get
            {
                if (instance == null)
                {
                    var go = new GameObject(typeof(OqupieManager).Name);
                    instance = go.AddComponent<OqupieManager>();
                    DontDestroyOnLoad(go);
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (Application.platform != RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
                return;

            // 메인 Activity가 바뀌어도 currentActivity 는 com.unity3d.player.UnityPlayer 클래스 에서 얻을 수 있다.
            using (var unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var oqupieManagerClass = new AndroidJavaClass("com.oqupie.oqupiesupport.OqupieManager"))
                    {
                        this.oqupieManagerAOS = oqupieManagerClass.CallStatic<AndroidJavaObject>("create", unityPlayerActivity);
                    }
                }
            }
        }

        public AppInfo GetAppInfo()
        {
            return new AppInfo();
        }

        /// <summary>
        /// 웹뷰를 띄운다.
        /// </summary>
        /// <param name="url">웹뷰 URL</param>
        /// <param name="post">POST / GET</param>
        /// <param name="appInfo">전송할 앱 정보</param>
        /// <param name="showTitleBar">타이틀바 표시여부</param>
        /// <param name="title">타이틀</param>
        /// <param name="color">타이틀바 배경색</param>
        public void OpenWebView(string url, AppInfo appInfo, bool showTitleBar, string title, Color color)
        {
            try
            {
                var color32 = (Color32)color;
                int red = color32.r;
                int green = color32.g;
                int blue = color32.b;
#if UNITY_ANDROID
                this.oqupieManagerAOS.Call("openWebViewByUnity", url, appInfo == null ? null : appInfo.ToQueryString(), showTitleBar, title, red, green, blue);
#elif UNITY_IOS
                    if (!url.ToLower().StartsWith("https"))
                    {
                        Debug.LogError("iOS에서는 https 요청만 보낼 수 있습니다.");
                        return;
                    }
                    oqupieOpenWebView(url, appInfo == null ? null : appInfo.ToQueryString(), showTitleBar, title, red, green, blue);
#endif
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}
