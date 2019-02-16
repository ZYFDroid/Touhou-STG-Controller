package com.zyfdroid.touhouremotectl;
import java.io.*;
import java.net.*;
import android.view.View.*;
import android.view.*;
import java.lang.reflect.*;
import android.widget.*;
import android.widget.SeekBar.*;

public class ControlActivity extends BaseActivity
{
	@Override
	public void onPrepareUi()
	{
		setContentView(R.layout.controller);

		((View)findViewById(R.id.basePan)).setOnTouchListener(new OnTouchListener(){

				@Override
				public boolean onTouch(View p1, MotionEvent p2)
				{
					return true;//fix multitouch
				}
			});
		OnTouchListener topKeyListener=new OnTouchListener(){

			@Override
			public boolean onTouch(View p1, MotionEvent p2)
			{
				try
				{
					Field field=OperateStruct.class.getDeclaredField("key" + ((TextView)p1).getText().toString());
					if (p2.getAction() == MotionEvent.ACTION_DOWN)
					{
						field.setInt(null, 1);
					}
					else if (p2.getAction() == MotionEvent.ACTION_UP)
					{
						field.setInt(null, 0);
					}
				}
				catch (NoSuchFieldException e)
				{}
				catch (IllegalAccessException e)
				{}
				return false;
			}
		};
		((Button)findViewById(R.id.btnC)).setOnTouchListener(topKeyListener);
		((Button)findViewById(R.id.btnX)).setOnTouchListener(topKeyListener);
		((Button)findViewById(R.id.btnEnter)).setOnTouchListener(topKeyListener);
		((Button)findViewById(R.id.btnEsc)).setOnTouchListener(topKeyListener);
		((Button)findViewById(R.id.btnP)).setOnTouchListener(topKeyListener);

		((ImageView)findViewById(R.id.ctlMoveAndShoot)).setOnTouchListener(new OnTouchListener(){

				@Override
				public boolean onTouch(View p1, MotionEvent p2)
				{
					float height=p1.getHeight();
					float y=p2.getY(0);
					OperateStruct.keyZ = (y < height / 3 * 2) ? 1 : 0;
					OperateStruct.keyShift = (y > height / 3) ? 1 : 0;
					
					OperateStruct.keyX = (y <0 ) ? 1 : 0;
					
					if (p2.getAction() == MotionEvent.ACTION_UP)
					{
						OperateStruct.keyZ = 0;
						OperateStruct.keyShift = 0;
						OperateStruct.keyX=0;
					}
					return true;
				}
			}
		);
		joystickZone = findViewById(R.id.joystickZone);
		((ImageView)findViewById(R.id.joystickThumb)).setOnTouchListener(new OnTouchListener(){
				float px=0,py=0;boolean down=false;
				@Override
				public boolean onTouch(View p1, MotionEvent p2)
				{
					if (p2.getAction() == MotionEvent.ACTION_DOWN)
					{
						px = p2.getX(0);py = p2.getY(0);down = true;
					}
					if (p2.getAction() == MotionEvent.ACTION_MOVE && down)
					{
						float tx=(p1.getTranslationX() + (p2.getX(0) - px));
						float ty=(p1.getTranslationY() + (p2.getY(0) - py));
						
						float mdist=(float)Math.sqrt(tx*tx+ty*ty);
						//摇杆范围从方形改成圆形
						float tdist=joystickZone.getWidth()/2f-p1.getWidth()/2f;
						
						if(mdist>tdist){
							tx = tx / mdist * tdist;
							ty = ty / mdist * tdist;
						}
						
						p1.setTranslationX(tx);
						p1.setTranslationY(ty);
						calculateRelativePos(
							(int)(p1.getTranslationX() / ((joystickZone.getWidth() - p1.getWidth()) / 2f) * 3.9),
							(int)(p1.getTranslationY() / ((joystickZone.getHeight() - p1.getHeight()) / 2f) * 3.9)
						);
					}
					if (p2.getAction() == MotionEvent.ACTION_UP)
					{
						down = false;
						p1.setTranslationX(0);
						p1.setTranslationY(0);
						calculateRelativePos(0, 0);
					}
					return true;
				}
			}
		);
		touchpoint = findViewById(R.id.touchpoint);
		((View)findViewById(R.id.touchScreenZone)).setOnTouchListener(new OnTouchListener(){
				int lastx=0,lasty=0;
				float scale=1;
				int touchcd=2;
				@Override
				public boolean onTouch(View p1, MotionEvent p2)
				{
					int action=p2.getAction();

					if (action == MotionEvent.ACTION_DOWN)
					{
						touchsensitive=touchsensitivebar.getProgress()+100;
						touchpoint.setVisibility(View.VISIBLE);
						scale = ((float)p1.getWidth()) / touchsensitive;
						lastx = (int)(p2.getX() / scale);lasty = (int)(p2.getY() / scale);
						touchpoint.setTranslationX(p2.getX() - touchpoint.getWidth() / 2);
						touchpoint.setTranslationY(p2.getY() - touchpoint.getHeight() / 2);
					}
					if (action == MotionEvent.ACTION_MOVE)
					{
						touchpoint.setTranslationX(p2.getX() - touchpoint.getWidth() / 2);
						touchpoint.setTranslationY(p2.getY() - touchpoint.getHeight() / 2);
						
						touchcd--;
						if (touchcd <= 0)
						{
							touchcd = 2;
							float lx=(int)(p2.getX() / scale) - lastx;
							float ly=(int)(p2.getY() / scale) - lasty;

							float vscale=Math.max(Math.abs(lx), Math.abs(ly));

							float sx=0,sy=0;
							if (vscale > 0.00001)
							{
								sx = lx / vscale;
								sy = ly / vscale;
							}
							float vlen=(float)Math.sqrt(lx * lx + ly * ly);
							float sscale=level(vlen);
							int fx=Math.round(sscale * sx);
							int fy=Math.round(sscale * sy);

							calculateRelativePos(fx, fy);

							lastx = (int)(p2.getX() / scale);lasty = (int)(p2.getY() / scale);
						}
					}
					if (action == MotionEvent.ACTION_UP)
					{
						touchpoint.setVisibility(View.GONE);
						calculateRelativePos(0, 0);
					}
					return true;
				}
			}
		);
		String ctl=load("ctl");
		if (!ctl.isEmpty())
		{
			controlType = Integer.parseInt(ctl);
		}
		touchsensitivebar=findViewById(R.id.touchSensitive);
		String sensitive=load("sv");
		if(!sensitive.isEmpty()){
			touchsensitive=Integer.parseInt(sensitive);
		}
		touchsensitivebar.setMax(1900);
		touchsensitivebar.setProgress((int)touchsensitive - 100);
		
		dpad=findViewById(R.id.dpad);
		dpadSizeBar=findViewById(R.id.dpadSizs);
		dpad.setOnTouchListener(new OnTouchListener(){

				@Override
				public boolean onTouch(View p1, MotionEvent p2)
				{
					float px=p2.getX();
					float py=p2.getY();
					float pw=p1.getWidth();
					float ph=p1.getHeight();
					OperateStruct.velU=(py < ph/3) ? 3 : 0;
					OperateStruct.velD=(py > ph/3*2) ? 3 : 0;
					OperateStruct.velL=(px < pw/3) ? 3 : 0;
					OperateStruct.velR=(px > pw/3*2) ? 3 : 0;
					if(p2.getAction()==MotionEvent.ACTION_UP){
						OperateStruct.velU=0;
						OperateStruct.velD=0;
						OperateStruct.velL=0;
						OperateStruct.velR=0;
					}
					
					
					
					
					return true;
				}
			}
		);
		
		dpadSizeBar.setMax(2500);
		dpadSizeBar.setProgress(1000);
		String dpadsize=load("ds");
		if(!dpadsize.isEmpty()){
			dpadSizeBar.setProgress(Integer.parseInt(dpadsize));
		}
		dpad.setScaleX((float)dpadSizeBar.getProgress() / 1000);
		dpad.setScaleY((float)dpadSizeBar.getProgress() / 1000);
		
		dpadSizeBar.setOnSeekBarChangeListener(new OnSeekBarChangeListener(){

				@Override
				public void onProgressChanged(SeekBar p1, int p2, boolean p3)
				{
					dpad.setScaleX((float)dpadSizeBar.getProgress() / 1000);
					dpad.setScaleY((float)dpadSizeBar.getProgress() / 1000);
				}

				@Override
				public void onStartTrackingTouch(SeekBar p1)
				{
				}

				@Override
				public void onStopTrackingTouch(SeekBar p1)
				{
					
					dpad.setScaleX((float)dpadSizeBar.getProgress() / 1000);
					dpad.setScaleY((float)dpadSizeBar.getProgress() / 1000);
					save("ds",String.valueOf(dpadSizeBar.getProgress()));
				}
			});
		
		
		SeekBar joysSizeBar=findViewById(R.id.joysSize);
		joysSizeBar.setMax(2500);
		joysSizeBar.setProgress(1000);
		String joysize=load("js");
		if(!joysize.isEmpty()){
			joysSizeBar.setProgress(Integer.parseInt(joysize));
		}
		joystickZone.setScaleX((float)joysSizeBar.getProgress() / 1000);
		joystickZone.setScaleY((float)joysSizeBar.getProgress() / 1000);

		joysSizeBar.setOnSeekBarChangeListener(new OnSeekBarChangeListener(){

				@Override
				public void onProgressChanged(SeekBar p1, int p2, boolean p3)
				{
					joystickZone.setScaleX((float)p1.getProgress() / 1000);
					joystickZone.setScaleY((float)p1.getProgress() / 1000);
				}

				@Override
				public void onStartTrackingTouch(SeekBar p1)
				{
				}

				@Override
				public void onStopTrackingTouch(SeekBar p1)
				{

					joystickZone.setScaleX((float)p1.getProgress() / 1000);
					joystickZone.setScaleY((float)p1.getProgress() / 1000);
					save("js",String.valueOf(p1.getProgress()));
				}
			});




		
		
		
		
		
		
		loadControlType();
	}
	FrameLayout joystickZone;
	ImageView touchpoint;
	float touchsensitive=440;
	SeekBar touchsensitivebar;
	SeekBar dpadSizeBar;
	ImageView dpad;
	
	
	public float level(float in)
	{
		if (in < 0)
		{return - level(-in);}
		if (in > 8)
		{return 3;}
		if (in > 3)
		{return 2;}
		if (in > 0.8f)
		{return 1;}
		return 0;
	}


	public void calculateRelativePos(int velx, int vely)
	{
		OperateStruct.velR = OperateStruct.velL = OperateStruct.velU = OperateStruct.velD = 0;
		if (velx < 0)
		{OperateStruct.velL = -velx;}
		else
		{OperateStruct.velR = velx;}
		if (vely < 0)
		{OperateStruct.velU = -vely;}
		else
		{OperateStruct.velD = vely;}
	}

	@Override
	public void onUiPrepared()
	{
		OperateStruct.reset();
		dpad.setPivotX(dpad.getWidth());
		dpad.setPivotY(dpad.getHeight());
		joystickZone.setPivotX(joystickZone.getWidth());
		joystickZone.setPivotY(joystickZone.getHeight());
	}

	@Override
	public void onFrame()
	{
		long t0=System.nanoTime();
		boolean success=false;
		OperateStruct.build();
		try
		{
			SocketClient.getInstance().send(OperateStruct.result);
			success = true;
		}
		catch (IOException e)
		{}
		float t=System.nanoTime() - t0;
		setViewText(R.id.txtStatus, "TIME=" + (t / 1000000) + "ms, SUCCESS=" + success + ", DATA=" + byte2HexFormatted(OperateStruct.result));
	}

	@Override
	public boolean isImmerseMode()
	{
		return true;
	}

	//复用减少GC
	StringBuilder str =new StringBuilder("233");
	private String byte2HexFormatted(byte[] arr)
	{
		str.delete(0, str.length());
		for (int i = 0; i < arr.length; i++)
		{
			String h = toBinStr(arr[i]);
			str.append(h);
			if (i < (arr.length - 1))
				str.append(' ');
		}
		return str.toString();
	}
	
	
	public String toBinStr(byte input)
	{
		int b2 = ((int)input * 2) / 2;
		if (b2 < 0) {
			b2 += 256;
		}
		StringBuilder sb0 = new StringBuilder();
		for (int i = 0; i < 8; i++)
		{
			sb0.insert(0,((b2 & 1) != 0) ? 1 : 0);
			b2 = b2 >> 1;
		}
		return sb0.toString();
	}
	/*
	public String toBinStr(byte input)
	{
		int b2=Byte.toUnsignedInt(input);//toUnsignedInt does not exist
		StringBuilder sb0=new StringBuilder();
		for (int i=0;i < 8;i++)
		{
			sb0.append(((b2 & 1) != 0) ? 1 : 0);
			b2 = b2 >> 1;
		}
		return sb0.reverse().toString();
	}
	*/
	@Override
	protected void onDestroy()
	{
		save("sv", String.valueOf(touchsensitivebar.getProgress()+100));
		
		super.onDestroy();
		try
		{
			OperateStruct.reset();
			SocketClient.getInstance().send(OperateStruct.result);
			SocketClient.getInstance().disposeInstance();
		}
		catch (UnknownHostException e)
		{}
		catch (SocketException e)
		{}
		catch (IOException e)
		{}
	}



	int controlType=0;

	String[] controlTypes={
		"摇杆",
		"触控",
		"按键"
	};

	int[] controlTypeView={
		R.id.joystickPan,
		R.id.touchScreenZone,
		R.id.dpadZone
	};



	public void svControlType(View p1)
	{
		controlType++;
		if (controlType >= controlTypes.length)
		{
			controlType = 0;
		}
		save("ctl", String.valueOf(controlType));
		loadControlType();
		
		onUiPrepared();
	}

	void loadControlType()
	{
		for (int i=0;i < controlTypeView.length;i++)
		{
			((View)findViewById(controlTypeView[i])).setVisibility(View.INVISIBLE);
		}
		((View)findViewById(controlTypeView[controlType])).setVisibility(View.VISIBLE);
		setViewText(R.id.btnControlType, controlTypes[controlType]);
	}


}

class OperateStruct
{
	//Define struct of control
	public static int velU=0;//0 to 3
	public static int velD=0;
	public static int velL=0;
	public static int velR=0;

	public static int keyShift=0; //0 or 1
	public static int keyZ=0;
	public static int keyX=0;
	public static int keyC=0;
	public static int keyEnter=0;
	public static int keyEsc=0;
	public static int keyP=0;

	public static byte[] result=new byte[2];

	public static void reset()
	{
		velU = 0;
		velD = 0;
		velL = 0;
		velR = 0;
		keyShift = 0;
		keyZ = 0;
		keyX = 0;
		keyC = 0;
		keyEnter = 0;
		keyEsc = 0;
		keyP = 0;
	}

	public static void build()
	{
		result[0] = 0;
		result[0] |= velU;
		result[0] = (byte)(result[0] << 2);
		result[0] |= velD;
		result[0] = (byte)(result[0] << 2);
		result[0] |= velL;
		result[0] = (byte)(result[0] << 2);
		result[0] |= velR;
		result[1] = 0;
		result[1] |= keyShift;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyZ;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyX;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyC;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyEnter;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyEsc;
		result[1] = (byte)(result[1] << 1);
		result[1] |= keyP;
		result[1] = (byte)(result[1] << 1);
		result[1] |= 0;
	}
}
