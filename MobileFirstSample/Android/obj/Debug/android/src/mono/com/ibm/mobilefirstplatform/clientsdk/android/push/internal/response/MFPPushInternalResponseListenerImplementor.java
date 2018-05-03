package mono.com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response;


public class MFPPushInternalResponseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response.MFPPushInternalResponseListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lcom/ibm/mobilefirstplatform/clientsdk/android/push/internal/response/MFPPushResponse;Ljava/lang/Throwable;Lorg/json/JSONObject;)V:GetOnFailure_Lcom_ibm_mobilefirstplatform_clientsdk_android_push_internal_response_MFPPushResponse_Ljava_lang_Throwable_Lorg_json_JSONObject_Handler:Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Internal.Response.IMFPPushInternalResponseListenerInvoker, MobileFirst.Android.Push\n" +
			"n_onSuccess:(Lcom/ibm/mobilefirstplatform/clientsdk/android/push/internal/response/MFPPushResponse;)V:GetOnSuccess_Lcom_ibm_mobilefirstplatform_clientsdk_android_push_internal_response_MFPPushResponse_Handler:Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Internal.Response.IMFPPushInternalResponseListenerInvoker, MobileFirst.Android.Push\n" +
			"";
		mono.android.Runtime.register ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Internal.Response.IMFPPushInternalResponseListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", MFPPushInternalResponseListenerImplementor.class, __md_methods);
	}


	public MFPPushInternalResponseListenerImplementor ()
	{
		super ();
		if (getClass () == MFPPushInternalResponseListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Ibm.Mobilefirstplatform.Clientsdk.Android.Push.Internal.Response.IMFPPushInternalResponseListenerImplementor, MobileFirst.Android.Push, Version=8.0.0.4, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response.MFPPushResponse p0, java.lang.Throwable p1, org.json.JSONObject p2)
	{
		n_onFailure (p0, p1, p2);
	}

	private native void n_onFailure (com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response.MFPPushResponse p0, java.lang.Throwable p1, org.json.JSONObject p2);


	public void onSuccess (com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response.MFPPushResponse p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (com.ibm.mobilefirstplatform.clientsdk.android.push.internal.response.MFPPushResponse p0);

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
