﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using RestSharp.Portable;
using System.Net.NetworkInformation;
//using Newtonsoft.Json;
//using WayBook.DataModel;
using System.Net;

namespace WayBook.Common
{
    public class RestfulClient
    {
        //public static Task<IRestResponse> LatestRequest { get; set; }
        public static async Task<RestfulResultModel<T>> Get<T>(string url) where T : new()
        {
            var result = new RestfulResultModel<T>();
            result.Model = default(T);
            result.State = RestfulResultState.ResponseDataError;
            result.ResponseResult = new ResponseResult();
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                result.State = RestfulResultState.NetworkNotAvailable;
            }
            try
            {
                result.ResponseResult = await Get(url);
            }
            catch (Exception)
            {
                result.State = RestfulResultState.OtherError;
            }
            if (result.ResponseResult.Status!= HttpStatusCode.OK)
            {
                result.State = RestfulResultState.EmptyResponseData;
            }
            else
            {
                try
                {
                    //result.Model = JsonConvert.DeserializeObject<T>(result.ResponseResult.Content);
                    result.State = RestfulResultState.Success;
                }
                catch (Exception)
                {
                    result.State = RestfulResultState.DeserializeDataError;
                }
            }

            return result;
        }


        /// <summary>
        /// For response, only support gbk encoding..
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeoutMilliSeconds"></param>
        /// <returns></returns>
        public static async Task<ResponseResult> Get(string url, int timeoutMilliSeconds = 10000)
        {
            return null;
            //var content = new ResponseResult();
            //using (var client = new RestClient(url))
            //{
            //    try
            //    {

            //        if (timeoutMilliSeconds > 0) client.Timeout = new TimeSpan(0, 0, 0, timeoutMilliSeconds);

            //        var request = new RestRequest();
            //        request.Method = HttpMethod.Get;
            //        request.AddHeader("cache-control", "no-cache");

            //        //var response = await client.Execute(request);
            //        var asyncHandler = client.Execute(request);
            //        LatestRequest = asyncHandler;
            //        var response = await asyncHandler;

            //        content.Status = response.StatusCode;

            //        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //        {
            //            return content;
            //        }

            //        // if (response.RawBytes != null)

            //        content.Content = Encoding.GetEncoding(EncodingNames.UTF8).GetString(response.RawBytes, 0, response.RawBytes.Length);

            //    }
            //    catch (Exception ex)
            //    {
            //        content.Status = HttpStatusCode.NotFound;
            //        //AppLogs.WriteError("RestfullClient", ex.Message);
            //        //AppLogs.WriteError("RestfullClient", ex.StackTrace);
            //        //throw ex;
            //    }
            //}
            //return content;
        }
        /// <summary>
        /// For response, only support gbk encoding..
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paras"></param>
        /// <param name="timeoutMilliSconds"></param>
        /// <returns></returns>
        public static async Task<string> Post(string url, Dictionary<string, string> paras, int timeoutMilliSconds = 10000)
        {
            return await Post(url, paras, EncodingNames.GBK, timeoutMilliSconds);
        }


        public static async Task<string> Post(string url, Dictionary<string, string> paras, string resultEncoding, int timeoutMilliSconds = 0)
        {
            return null;
            //if (!NetworkInterface.GetIsNetworkAvailable())
            //{
            //    return string.Empty;
            //}

            //var content = string.Empty;
            //using (var client = new RestClient(url))
            //{
            //    try
            //    {
            //        if (timeoutMilliSconds > 0) client.Timeout = new TimeSpan(0, 0, 0, timeoutMilliSconds);

            //        var request = new RestRequest(HttpMethod.Post);
            //        foreach (var param in paras)
            //        {
            //            request.AddParameter(param.Key, param.Value);
            //        }

            //        var response = await client.Execute(request);
            //        content = Encoding.GetEncoding(resultEncoding).GetString(response.RawBytes, 0, response.RawBytes.Length);
            //    }
            //    catch (Exception ex)
            //    {
            //        AppLogs.WriteError("RestfullClient.post", ex.Message);
            //        AppLogs.WriteError("RestfullClient.post", ex.StackTrace);
            //    }
            //}
            //return content;

        }


    }

    public enum RestfulResultState
    {
        Success = 0,
        NetworkNotAvailable = 1,
        ResponseDataError = 2,
        DeserializeDataError = 3,
        EmptyResponseData = 4,
        OtherError = 5
    }


    public class EncodingNames
    {
        public const string GB2312 = "GB2312";
        public const string GBK = "GBK";
        public const string UTF8 = "UTF-8";
        public const string UNICODE = "Unicode";
        public const string ASCII = "ASCII";
    }

    public class RestfulResultModel<T> where T : new()
    {
        public RestfulResultState State { get; set; }
        public T Model { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class ResponseResult
    {
        public HttpStatusCode Status { get; set; }
        public string Content { get; set; }
    }

}
