package mono.com.worklight.wlclient.api;


public class WLLogoutResponseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLLogoutResponseListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lcom/worklight/wlclient/api/WLFailResponse;)V:GetOnFailure_Lcom_worklight_wlclient_api_WLFailResponse_Handler:Worklight.Android.IWLLogoutResponseListenerInvoker, Worklight.Android\n" +
			"n_onSuccess:()V:GetOnSuccessHandler:Worklight.Android.IWLLogoutResponseListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Android.IWLLogoutResponseListenerImplementor, Worklight.Android, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null", WLLogoutResponseListenerImplementor.class, __md_methods);
	}


	public WLLogoutResponseListenerImplementor ()
	{
		super ();
		if (getClass () == WLLogoutResponseListenerImplementor.class)
			mono.android.TypeManager.Activate ("Worklight.Android.IWLLogoutResponseListenerImplementor, Worklight.Android, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (com.worklight.wlclient.api.WLFailResponse p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.worklight.wlclient.api.WLFailResponse p0);


	public void onSuccess ()
	{
		n_onSuccess ();
	}

	private native void n_onSuccess ();

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
