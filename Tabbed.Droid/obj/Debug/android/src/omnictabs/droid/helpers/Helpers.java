package omnictabs.droid.helpers;


public class Helpers
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("OmnicTabs.Droid.Helpers.Helpers, OmnicTabs.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Helpers.class, __md_methods);
	}


	public Helpers () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Helpers.class)
			mono.android.TypeManager.Activate ("OmnicTabs.Droid.Helpers.Helpers, OmnicTabs.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);

	java.util.ArrayList refList;
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
