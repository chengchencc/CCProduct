using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CC.Product.Core.Utilities
{
    public class Encoder
    {
        /// <summary>  
        /// 计算字符串的MD5值  (encoding UTF8)
        /// </summary>  
        /// <param name="msg">要计算的字符串</param>  
        /// <returns></returns>  
        public static string GetMD5FromString(string msg)
        {

            //1.创建一个用来计算MD5值的类的对象  
            using (MD5 md5 = MD5.Create())
            {

                //把字符串转换为byte[]  
                //注意：如果字符串中包含汉字，则这里会把汉字使用utf-8编码转换为byte[]，当其他地方  
                //计算MD5值的时候，如果对汉字使用了不同的编码，则同样的汉字生成的byte[]是不一样的，所以计算出的MD5值也就不一样了。  
                byte[] msgBuffer = Encoding.UTF8.GetBytes(msg);

                //2.计算给定字符串的MD5值  
                //返回值就是就算后的MD5值,如何把一个长度为16的byte[]数组转换为一个长度为32的字符串：就是把每个byte转成16进制同时保留2位即可。  
                byte[] md5Buffer = md5.ComputeHash(msgBuffer);
                md5.Clear();//释放资源  

                StringBuilder sbMd5 = new StringBuilder();
                for (int i = 0; i < md5Buffer.Length; i++)
                {
                    sbMd5.Append(md5Buffer[i].ToString("x2"));
                }
                return sbMd5.ToString();

            }

        }  

    }
}
