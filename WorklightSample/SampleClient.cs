using System;
using Worklight;

using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Worklight.Push;
using System.Threading;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorklightSample
{
    /// <summary>
    /// Sample Worklight client 
    /// </summary>
    public class SampleClient
    {
        #region Fields

        private string pushAlias = "myAlias2";
        private string appRealm = "UserLogin";
        private JObject metadata = (JObject)JObject.Parse(" {\"platform\" : \"Xamarin\" } ");

        #endregion

        #region Properties
        SecurityCheckChallengeHandler customCH = new CustomChallengeHandler("UserLogin");
        public IWorklightClient client { get; private set; }

        public IWorklightPush push { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is push supported.
        /// </summary>
        /// <value><c>true</c> if this instance is push supported; otherwise, <c>false</c>.</value>
        public bool IsPushSupported
        {
            get
            {
                try
                {
                    return push.IsPushSupported;
                }
                catch
                {
                    return false;
                }

            }

        }

        #endregion

        #region Constuctors

        public SampleClient(IWorklightClient wlc, IWorklightPush push)
        {
            this.client = wlc;
            this.push = push;
            SecurityCheckChallengeHandler customCH = new CustomChallengeHandler(appRealm);
            client.RegisterChallengeHandler(customCH);
            push.Initialize();
        }

        #endregion

        #region Async functions
        public async Task<WorklightResult> UnprotectedInvokeAsync()
        {
            var result = new WorklightResult();
            try
            {
                StringBuilder uriBuilder = new StringBuilder()
                    .Append("/adapters")
                    .Append("/ResourceAdapter") //Name of the adapter
                    .Append("/publicData");    // Name of the adapter procedure

                WorklightResourceRequest rr = client.ResourceRequest(new Uri(uriBuilder.ToString(), UriKind.Relative),
                                                                     "GET");

                WorklightResponse resp = await rr.Send();

                result.Success = resp.Success;
                //result.Message = (resp.Success) ? "Connected" : resp.Message;
                result.Response = resp.ResponseText;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
        public async Task<WorklightResult> ProtectedInvokeAsync()
        {
            var result = new WorklightResult();
            try
            {
                StringBuilder uriBuilder = new StringBuilder()
                    .Append("/adapters")
                    .Append("/ResourceAdapter") //Name of the adapter
                    .Append("/balance");    // Name of the adapter procedure

                WorklightResourceRequest rr = client.ResourceRequest(new Uri(uriBuilder.ToString(), UriKind.Relative),
                                                                     "GET",
                                                                     "accessRestricted");

                WorklightResponse resp = await rr.Send();

                result.Success = resp.Success;
                //result.Message = (resp.Success) ? "Connected" : resp.Message;
                result.Response = resp.Success ? "Your account balance is " + resp.ResponseText : resp.Message;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
        public async Task<String> OnLogin()
        {
            WorklightResponse res = null;
            bool result = false;
            JObject creds = new JObject();
            try
            {
                creds.Add("username", "user3");
                creds.Add("password", "user3");
                CustomChallengeHandler ch = new CustomChallengeHandler(appRealm);
                client.RegisterChallengeHandler(ch);
                res = await ch.login(creds);


                result = res.Success;
                if (res.Success)
                {
                    result = res.Success;
                    Debug.WriteLine("Logged in successfully" + res.ResponseJSON);
                }
            }
            catch (Exception ex)
            {
                result = false;
                Debug.WriteLine("Login failure" + res.ResponseJSON);
            }
            return result.ToString();

        }
        public async Task<String> OnLogout()
        {
            WorklightResponse res = null;
            bool result = false;
            try
            {

                CustomChallengeHandler ch = new CustomChallengeHandler(appRealm);
                res = await ch.logout(appRealm);
                if (res.Success)
                {
                    result = res.Success;
                    Debug.WriteLine("Logged out successfully" + res.ResponseJSON);
                }
            }
            catch (Exception ex)
            {
                result = false;
                Debug.WriteLine("Logout failure" + res.ResponseJSON);
            }
            return result.ToString();
        }

        public async Task<WorklightResult> SubscribeAsync()
        {
            var result = new WorklightResult();

            try
            {
                var resp = await push.Subscribe(new string[] { "Xamarin" });
                push.NotificationReceived += handleNotification;
                result.Success = resp.Success;
                result.Message = "Subscribed";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<WorklightResult> RegisterAsync()
        {
            var result = new WorklightResult();
            Console.WriteLine("inside RegisterAsync");
            try
            {
                Console.WriteLine("Inside try within registerdevice");
                var resp = await push.RegisterDevice(new JObject());
                result.Success = resp.Success;
                result.Message = "Registered";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<WorklightResult> UnregisterAsync()
        {
            var result = new WorklightResult();

            try
            {
                var resp = await push.UnregisterDevice();
                result.Success = resp.Success;
                result.Message = "Unregistered";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
        public static void handleNotification(object sender, EventArgs e)
        {
            PushEventArgs eventArgs = (PushEventArgs)e;
            Console.WriteLine("Notification received. Payload is " + eventArgs.Payload +
                              ". URL is " + eventArgs.Url);
            HomePage._this.ShowAlert("Notified", eventArgs.Alert, "OK");
        }

        public async Task<WorklightResult> UnSubscribeAsync()
        {
            var result = new WorklightResult();

            try
            {
                var resp = await UnsubscribePush();

                result.Success = resp.Success;
                result.Message = "Unsubscribed";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<WorklightResult> GetSubscriptionsAsync()
        {
            var result = new WorklightResult();

            try
            {
                var resp = await GetSubscriptions();

                result.Success = resp.Success;
                result.Message = "All Subscriptions";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<WorklightResult> GetTagsAsync()
        {
            var result = new WorklightResult();

            try
            {
                var resp = await GetTags();

                result.Success = resp.Success;
                result.Message = "All tags";
                result.Response = (resp.ResponseJSON != null) ? resp.ResponseJSON.ToString() : "";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        #endregion

        #region Worklight Methods

        /// <summary>
        /// Unsubscribes from push notifications
        /// </summary>
        /// <returns>The push.</returns>
        private async Task<MFPPushMessageResponse> UnsubscribePush()
        {
            try
            {
                return await push.Unsubscribe(new string[] { "xamarin " });
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Subscribes to push notifications
        /// </summary>
        /// <param name="callBack">Call back.</param>
        private async Task<MFPPushMessageResponse> SubscribePush()
        {
            Console.WriteLine("Subscribing to push");
            return await push.Subscribe(new string[] { "xamarin" });
        }

        private async Task<MFPPushMessageResponse> GetSubscriptions()
        {
            Console.WriteLine("Getting list of subscriptions");
            return await push.GetSubscriptions();
        }

        private async Task<MFPPushMessageResponse> GetTags()
        {
            Console.WriteLine("Getting list of all tags");
            return await push.GetTags();
        }


        /// <summary>
        /// Invokes the procedured
        /// </summary>
        /// <returns>The proc.</returns>
        private async Task<WorklightResult> InvokeProc()
        {
            var result = new WorklightResult();

            try
            {
                client.Analytics.Log("trying to invoking procedure");
                System.Diagnostics.Debug.WriteLine("Trying to invoke proc");
                WorklightProcedureInvocationData invocationData = new WorklightProcedureInvocationData("SampleHTTPAdapter", "getFeed", new object[] { "technology" });
                WorklightResponse task = await client.InvokeProcedure(invocationData);
                client.Analytics.Log("invoke response : " + task.Success);
                StringBuilder retval = new StringBuilder();

                result.Success = task.Success;

                if (task.Success)
                {
                    JArray jsonArray = (JArray)task.ResponseJSON["rss"]["channel"]["item"];
                    foreach (JObject title in jsonArray)
                    {
                        JToken titleString;
                        title.TryGetValue("title", out titleString);
                        retval.Append(titleString.ToString());
                        retval.AppendLine();
                    }
                }
                else
                {
                    retval.Append("Failure: " + task.Message);
                }

                result.Message = retval.ToString();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;

        }

        #endregion
    }

}

