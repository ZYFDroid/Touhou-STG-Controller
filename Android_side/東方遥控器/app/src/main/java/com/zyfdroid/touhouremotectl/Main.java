package com.zyfdroid.touhouremotectl;
import android.app.Application;
import android.os.*;
public class Main extends Application
{

	@Override  
	public void onCreate()
	{  
		super.onCreate();  
		CrashHandler crashHandler = CrashHandler.getInstance();  
		crashHandler.init(getApplicationContext());  
	}
}

