using System.Collections.Generic;
using UnityEngine;

namespace Oqupie
{
    /// <summary>
    /// 앱 정보를 담아서 전송하는 데이터 클래스
    /// </summary>
    public class AppInfo
    {
        
        /// <summary>
        /// 추가 정보
        /// </summary>
        public Dictionary<string, string> additionalInfo = new Dictionary<string, string>();

        /// <summary>
        /// 추가 정보를 추가한다.
        /// </summary>
        /// <param name="key">키</param>
        /// <param name="value">값</param>
        public void AddInfo(string key, string value)
        {
            this.additionalInfo.Add(key, value);
        }

        /// <summary>
        /// 추가정보를 쿼리스트링형태로 바꾼다.
        /// </summary>
        /// <returns>string</returns>
        public string ToQueryString()
        {
            var queryStringList = new List<string>();
            foreach(var item in this.additionalInfo)
            {
                queryStringList.Add(item.Key + "=" + item.Value);
            }
            return string.Join("&", queryStringList);
        }
    }
}
