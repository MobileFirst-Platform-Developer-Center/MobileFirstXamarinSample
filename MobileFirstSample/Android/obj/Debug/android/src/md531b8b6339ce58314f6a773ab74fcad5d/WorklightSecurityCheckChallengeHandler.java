package md531b8b6339ce58314f6a773ab74fcad5d;


public class WorklightSecurityCheckChallengeHandler
	extends com.worklight.wlclient.api.challengehandler.SecurityCheckChallengeHandler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleSuccess:(Lorg/json/JSONObject;)V:GetHandleSuccess_Lorg_json_JSONObject_Handler\n" +
			"n_handleFailure:(Lorg/json/JSONObject;)V:GetHandleFailure_Lorg_json_JSONObject_Handler\n" +
			"n_handleChallenge:(Lorg/json/JSONObject;)V:GetHandleChallenge_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.WorklightSecurityCheckChallengeHandler, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", WorklightSecurityCheckChallengeHandler.class, __md_methods);
	}


	public WorklightSecurityCheckChallengeHandler (java.lang.String p0)
	{
		super (p0);
		if (getClass () == WorklightSecurityCheckChallengeHandler.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.WorklightSecurityCheckChallengeHandler, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public void handleSuccess (org.json.JSONObject p0)
	{
		n_handleSuccess (p0);
	}

	private native void n_handleSuccess (org.json.JSONObject p0);


	public void handleFailure (org.json.JSONObject p0)
	{
		n_handleFailure (p0);
	}

	private native void n_handleFailure (org.json.JSONObject p0);


	public void handleChallenge (org.json.JSONObject p0)
	{
		n_handleChallenge (p0);
	}

	private native void n_handleChallenge (org.json.JSONObject p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
