using System;
using System.Collections.Generic;
using Worklight;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Worklight.Xamarin.Android;


namespace WorklightSample
{
    public class CustomChallengeHandler : SecurityCheckChallengeHandler
    {
        WorklightAuthorizationManager wlauth = WorklightAuthorizationManagerAndroid.Instance;
        public LoginFormInfo LoginFormParameters { get; set; }

        IWorklightClient client;
        private bool authSuccess = false;
        private bool isAdapterAuth = false;
        private bool shouldSubmitLoginForm = false;
        private bool shouldSubmitAnswer = false;
        private bool isChallenged = false;

        public JObject challengeAnswer = null;

        public CustomChallengeHandler(string realm)
        {
            this.SecurityCheck = realm;
        }

        public override string SecurityCheck
        {
            get; set;
        }

        public override JObject GetChallengeAnswer()
        {
            return challengeAnswer;
        }

        public override bool ShouldSubmitChallengeAnswer()
        {
            return shouldSubmitAnswer;
        }

        public override void HandleChallenge(object challenge)
        {
            isChallenged = true;
            Console.WriteLine("We were challenged.. so we are handling it");
            Dictionary<String, String> parms = new Dictionary<String, String>();

            JObject creds = new JObject();
            creds.Add("username", "user3");
            creds.Add("password", "user3");
            challengeAnswer = creds;
            shouldSubmitAnswer = true;

        }

        public async Task<WorklightResponse> login(JObject creds)
        {

            WorklightResponse response = null;
            if (isChallenged)
            {
                creds.Add("username", "user3");
                creds.Add("password", "user3");
                challengeAnswer = creds;
                shouldSubmitAnswer = true;

            }

            else
            {
                challengeAnswer = creds;
                //shouldSubmitAnswer = true;
                response = await App.WorklightClient.client.AuthorizationManager.Login(this.SecurityCheck, this.challengeAnswer);

                if (response.Success)
                {
                    Debug.WriteLine(response.ResponseText);
                }
            }
            return response;
        }

        public async Task<WorklightResponse> logout(String SecurityCheck)
        {
            WorklightResponse response = await App.WorklightClient.client.AuthorizationManager.Logout(SecurityCheck);

            if (response.Success)
            {

                this.isChallenged = false;
                this.shouldSubmitAnswer = true;

            }
            return response;
        }
        public override void HandleSuccess(JObject identity)
        {
            Console.WriteLine("Success " + identity.ToString());
        }

        public override void HandleFailure(JObject error)
        {
            Console.WriteLine("Failure " + error.ToString());
        }
    }
}

