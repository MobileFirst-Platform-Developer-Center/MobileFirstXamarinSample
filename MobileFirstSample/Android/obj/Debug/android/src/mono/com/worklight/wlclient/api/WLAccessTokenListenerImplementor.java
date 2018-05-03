package mono.com.worklight.wlclient.api;


public class WLAccessTokenListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLAccessTokenListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lcom/worklight/wlclient/api/WLFailResponse;)V:GetOnFailure_Lcom_worklight_wlclient_api_WLFailResponse_Handler:Worklight.Android.IWLAccessTokenListenerInvoker, Worklight.Android\n" +
			"n_onSuccess:(Lcom/worklight/wlclient/auth/AccessToken;)V:GetOnSuccess_Lcom_worklight_wlclient_auth_AccessToken_Handler:Worklight.Android.IWLAccessTokenListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Android.IWLAccessTokenListenerImplementor, Worklight.Android, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null", WLAccessTokenListenerImplementor.class, __md_methods);
	}


	public WLAccessTokenListenerImplementor ()
	{
		super ();
		if (getClass () == WLAccessTokenListenerImplementor.class)
			mono.android.TypeManager.Activate ("Worklight.Android.IWLAccessTokenListenerImplementor, Worklight.Android, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (com.worklight.wlclient.api.WLFailResponse p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.worklight.wlclient.api.WLFailResponse p0);


	public void onSuccess (com.worklight.wlclient.auth.AccessToken p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (com.worklight.wlclient.auth.AccessToken p0);

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
