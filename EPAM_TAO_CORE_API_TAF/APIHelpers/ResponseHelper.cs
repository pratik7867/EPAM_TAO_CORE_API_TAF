using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using RestSharp;
using EPAM_TAO_CORE_UI_TAF.UI_Helpers;

namespace EPAM_TAO_CORE_API_TAF.APIHelpers
{
    public class ResponseHelper
    {
        public static RestResponse ExecuteRequest(RestClient restClient, RestRequest restRequest)
        {
            try
            {
                return restClient.Execute(restRequest);
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static DC GetContent<DC>(RestResponse restResponse)
        {
            try
            {
               return JsonConvert.DeserializeObject<DC>(restResponse.Content);
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static int GetStatusCode(RestResponse restResponse)
        {
            try
            {
                HttpStatusCode httpStatusCode = restResponse.StatusCode;
                return (int)httpStatusCode;
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static string GetStatusDescription(RestResponse restResponse)
        {
            try
            {
                return restResponse.StatusDescription;
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static bool GetRequestSuccessFlag(RestResponse restResponse)
        {
            try
            {
                return restResponse.IsSuccessful;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static IList<Parameter> GetResponseHeaders(RestResponse restResponse)
        {
            try
            {
                return (IList<Parameter>)restResponse.Headers;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        public static IList<Cookie> GetResponseCookies(RestResponse restResponse)
        {
            try
            {
                return (IList<Cookie>)restResponse.Cookies;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }
    }
}
