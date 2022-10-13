using System;
using System.Collections.Generic;
using System.Reflection;
using RestSharp;
using EPAM_TAO_CORE_UI_TAF.UI_Helpers;

namespace EPAM_TAO_CORE_API_TAF.APIHelpers
{
    public class RequestHelper
    {
        static RestRequest restRequest;
        static Dictionary<string, string> DictOfRequestHeaders;

        private static Dictionary<string, string> getRequestHeaders()
        {
            try
            {
                if (DictOfRequestHeaders == null)
                {
                    DictOfRequestHeaders = new Dictionary<string, string>();

                    DictOfRequestHeaders.Add("Accept", "*/*");
                    DictOfRequestHeaders.Add("Content-Type", "application/json");
                }

                return DictOfRequestHeaders;
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
            
        }

        #region GET REQUEST
        public static RestRequest CreateGetRequest(string strResource)
        {
            try
            {
                restRequest = new RestRequest(strResource, Method.Get);

                foreach (var item in getRequestHeaders())
                {
                    if (item.Key != "Content-Type")
                    {
                        restRequest.AddHeader(item.Key, item.Value);
                    }
                }

                return restRequest;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        #endregion

        #region POST REQUEST
        public static RestRequest CreatePostRequest(string strResource, string strPayload, DataFormat dataFormat)
        {
            try
            {
                restRequest = new RestRequest(strResource, Method.Post);
                restRequest.RequestFormat = dataFormat;

                foreach (var item in getRequestHeaders())
                {
                    restRequest.AddHeader(item.Key, item.Value);
                }

                restRequest.AddBody(strPayload);

                return restRequest;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        #endregion

        #region PUT REQUEST
        public static RestRequest CreatePutRequest(string strResource, string strPayload, DataFormat dataFormat)
        {
            try
            {
                restRequest = new RestRequest(strResource, Method.Put);
                restRequest.RequestFormat = dataFormat;

                foreach (var item in getRequestHeaders())
                {
                    restRequest.AddHeader(item.Key, item.Value);
                }

                restRequest.AddBody(strPayload);

                return restRequest;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        #endregion

        #region PATCH REQUEST
        public static RestRequest CreatePatchRequest(string strResource, string strPayload, DataFormat dataFormat)
        {
            try
            {
                restRequest = new RestRequest(strResource, Method.Patch);
                restRequest.RequestFormat = dataFormat;

                foreach (var item in getRequestHeaders())
                {
                    restRequest.AddHeader(item.Key, item.Value);
                }

                restRequest.AddBody(strPayload);

                return restRequest;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }
        }

        #endregion

        #region DELETE REQUEST
        public static RestRequest CreateDeleteRequest(string strResource)
        {
            try
            {
                restRequest = new RestRequest(strResource, Method.Delete);

                foreach (var item in getRequestHeaders())
                {
                    if (item.Key != "Content-Type")
                    {
                        restRequest.AddHeader(item.Key, item.Value);
                    }
                }

                return restRequest;
            }
            catch (Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;                
            }
        }

        #endregion

    }
}
