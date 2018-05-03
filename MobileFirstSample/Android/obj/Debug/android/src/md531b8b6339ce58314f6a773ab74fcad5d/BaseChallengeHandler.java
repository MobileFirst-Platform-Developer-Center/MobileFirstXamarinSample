package md531b8b6339ce58314f6a773ab74fcad5d;


public abstract class BaseChallengeHandler
	extends com.worklight.wlclient.api.challengehandler.BaseChallengeHandler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.BaseChallengeHandler, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", BaseChallengeHandler.class, __md_methods);
	}


	public BaseChallengeHandler (java.lang.String p0)
	{
		super (p0);
		if (getClass () == BaseChallengeHandler.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.BaseChallengeHandler, MobileFirst.Xamarin.Android, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}

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
