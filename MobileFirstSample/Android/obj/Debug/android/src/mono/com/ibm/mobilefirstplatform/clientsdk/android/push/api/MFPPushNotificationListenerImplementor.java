package mono.com.ibm.mobilefirstplatform.clientsdk.android.push.api;


public class MFPPushNotificationListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPPushNotificationListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Lcom/ibm/mobilefirstplatform/clientsdk/android/push/api/MFPSimplePushNotification;)V:GetOnReceive_Lcom_ibm_mobilefirstplatform_clientsdk_android_push_api_MFPSimplePushNotification_Handler:Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushNotificationListenerInvoker, MobileFirst.Android.Push\n" +
			"";
		mono.android.Runtime.register ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushNotificationListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", MFPPushNotificationListenerImplementor.class, __md_methods);
	}


	public MFPPushNotificationListenerImplementor ()
	{
		super ();
		if (getClass () == MFPPushNotificationListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushNotificationListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPSimplePushNotification p0)
	{
		n_onReceive (p0);
	}

	private native void n_onReceive (com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPSimplePushNotification p0);

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
