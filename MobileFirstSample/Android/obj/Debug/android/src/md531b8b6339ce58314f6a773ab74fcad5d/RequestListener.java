package md531b8b6339ce58314f6a773ab74fcad5d;


public class RequestListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.WLRequestListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lcom/worklight/wlclient/api/WLFailResponse;)V:GetOnFailure_Lcom_worklight_wlclient_api_WLFailResponse_Handler:Worklight.Android.IWLRequestListenerInvoker, Worklight.Android\n" +
			"n_onSuccess:(Lcom/worklight/wlclient/api/WLResponse;)V:GetOnSuccess_Lcom_worklight_wlclient_api_WLResponse_Handler:Worklight.Android.IWLRequestListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.RequestListener, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", RequestListener.class, __md_methods);
	}


	public RequestListener ()
	{
		super ();
		if (getClass () == RequestListener.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.RequestListener, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (com.worklight.wlclient.api.WLFailResponse p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.worklight.wlclient.api.WLFailResponse p0);


	public void onSuccess (com.worklight.wlclient.api.WLResponse p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (com.worklight.wlclient.api.WLResponse p0);

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
