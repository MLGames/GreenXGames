//MAPNAV Navigation ToolKit v.1.0
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapNav))]
public class MapNavInspector : Editor {
	
	bool showZoom =true;
	private string[] maptype = new string[]{"map","sat","hyb"}; //Provide here the available map-types for your maps provider.
	private SerializedObject myLoc;
	private SerializedProperty
		simGPS,
		userSpeed,
		realSpeed,
		fixLat,
		fixLon,
		heading,
		zoom,
		key,
		minZoom,
		maxZoom,
		index,
		triDView,
		camDist,
		camAngle,
		maxWait,
		buttons,
		initTime,
		dmsLat,
		dmsLon,
		updateRate,
		autoCenter,
		fixPointer;
		
	private void OnEnable(){

 		myLoc = new SerializedObject(target);
		simGPS = myLoc.FindProperty("simGPS");
		userSpeed = myLoc.FindProperty("userSpeed");
		realSpeed = myLoc.FindProperty("realSpeed");
		fixLat = myLoc.FindProperty("fixLat");
		fixLon = myLoc.FindProperty("fixLon");
		heading = myLoc.FindProperty("heading");
		zoom = myLoc.FindProperty("zoom");
		key = myLoc.FindProperty("key");
		minZoom = myLoc.FindProperty("minZoom");
		maxZoom = myLoc.FindProperty("maxZoom");
		index = myLoc.FindProperty("index");
		triDView = myLoc.FindProperty("triDView");
		camDist = myLoc.FindProperty("camDist");
		camAngle = myLoc.FindProperty("camAngle");
		maxWait = myLoc.FindProperty("maxWait");
		buttons = myLoc.FindProperty("buttons");
		initTime = myLoc.FindProperty("initTime");
		dmsLat = myLoc.FindProperty("dmsLat");
		dmsLon = myLoc.FindProperty("dmsLon");
		updateRate = myLoc.FindProperty("updateRate");
		autoCenter = myLoc.FindProperty("autoCenter");
		fixPointer = myLoc.FindProperty("fixPointer");
	}
 
	
	public override void OnInspectorGUI () {
		
		myLoc.Update();
		
		//GPS Emulator 
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(key,new GUIContent("Maps AppKey"));
		EditorGUILayout.PropertyField(simGPS,new GUIContent("GPS Emulator"));
		EditorGUI.indentLevel++;
		if(simGPS.boolValue){
			
			//Emulator Pointer Speed 
			EditorGUILayout.PropertyField(userSpeed,new GUIContent("Pointer Speed"),GUILayout.MaxWidth(250));
			EditorGUILayout.PropertyField(realSpeed,new GUIContent("Realistic Speed"),GUILayout.MaxWidth(250));
			EditorGUILayout.HelpBox("On Emulator Mode use WASD or arrow keys to navigate.",MessageType.Info);
			EditorGUILayout.Space();
		}	
		EditorGUI.indentLevel--;
		
		//Latitude / Longitude 
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(fixLat,new GUIContent("Latitude (decimal)"),GUILayout.Width(250));
		EditorGUILayout.LabelField(dmsLat.stringValue);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(fixLon,new GUIContent("Longitude (decimal)"),GUILayout.Width(250));
		EditorGUILayout.LabelField(dmsLon.stringValue);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.LabelField("Heading(Read Only)",(Mathf.Round(heading.floatValue)).ToString(),GUILayout.Width(250));
		EditorGUILayout.Space();
		
		//Zoom Control 
		showZoom = EditorGUILayout.Foldout(showZoom,"Zoom Levels");
		EditorGUILayout.Space();
		if(showZoom){
		EditorGUI.indentLevel++;	
		EditorGUILayout.IntSlider(zoom,0,20,new GUIContent("Default/Current"));	
		EditorGUILayout.IntSlider(minZoom,0,20,new GUIContent("Min."));
		EditorGUILayout.IntSlider(maxZoom,0,20,new GUIContent("Max."));
		EditorGUILayout.Space();
		EditorGUI.indentLevel--; 
		}
		
		//MapQuest MapType
		index.intValue = EditorGUILayout.Popup("Maptype",index.intValue,maptype);
		EditorGUILayout.Space();
		
		//3D Perspective Camera View
		EditorGUILayout.PropertyField(triDView,new GUIContent("3D View"));
		
		EditorGUI.indentLevel++;
		//Camera Distance to User
		//3D
		
		if(triDView.boolValue==true){
			EditorGUILayout.Slider(camDist,1,100,new GUIContent("Camera Dist"));	
			EditorGUILayout.IntSlider(camAngle,1,89,new GUIContent("Camera Angle"));
		}
		//2D
		else{
			//Camera Height from Map
			EditorGUILayout.Slider(camDist,1,20,new GUIContent("Camera Height"));	
		}
		
		//Fixed Pointer Aspect
		if(triDView.boolValue==false){
			EditorGUILayout.PropertyField(fixPointer,new GUIContent("Fixed Pointer Aspect"),GUILayout.Width(250));
		}
		
		EditorGUI.indentLevel--; 
		
		//Auto Center 
		EditorGUILayout.PropertyField(autoCenter);

		//User Interface Buttons
		EditorGUILayout.PropertyField(buttons,new GUIContent("GUI Buttons"));
		EditorGUILayout.Space();
		
		//Additional Config Options
		if(!simGPS.boolValue){	
			EditorGUILayout.PropertyField(updateRate,new GUIContent("Pointer Update Rate"),GUILayout.MaxWidth(200));
			EditorGUILayout.PropertyField(maxWait,new GUIContent("GPS Fix Timeout"),GUILayout.MaxWidth(200));	
		}	
		EditorGUILayout.PropertyField(initTime,new GUIContent("Init. Time"),GUILayout.MaxWidth(200));
		EditorGUILayout.Space();
		if(simGPS.boolValue){
			EditorGUILayout.HelpBox("Deactivate the GPS emulator before building for mobile devices.",MessageType.Warning);
		}
		
		myLoc.ApplyModifiedProperties ();
	}
}