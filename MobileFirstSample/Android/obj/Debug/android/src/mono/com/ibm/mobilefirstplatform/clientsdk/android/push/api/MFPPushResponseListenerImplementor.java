package mono.com.ibm.mobilefirstplatform.clientsdk.android.push.api;


public class MFPPushResponseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPPushResponseListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lcom/ibm/mobilefirstplatform/clientsdk/android/push/api/MFPPushException;)V:GetOnFailure_Lcom_ibm_mobilefirstplatform_clientsdk_android_push_api_MFPPushException_Handler:Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushResponseListenerInvoker, MobileFirst.Android.Push\n" +
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushResponseListenerInvoker, MobileFirst.Android.Push\n" +
			"";
		mono.android.Runtime.register ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushResponseListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", MFPPushResponseListenerImplementor.class, __md_methods);
	}


	public MFPPushResponseListenerImplementor ()
	{
		super ();
		if (getClass () == MFPPushResponseListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Api.IMFPPushResponseListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPPushException p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.ibm.mobilefirstplatform.clientsdk.android.push.api.MFPPushException p0);


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

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
