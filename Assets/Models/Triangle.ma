//Maya ASCII 2015 scene
//Name: Triangle.ma
//Last modified: Sun, Mar 29, 2015 01:21:22 AM
//Codeset: 1252
requires maya "2015";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2015";
fileInfo "version" "2015";
fileInfo "cutIdentifier" "201405190330-916664";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "triangle";
	setAttr ".t" -type "double3" 0.077578147686062415 -1.2515151057290586 -0.18082753675701468 ;
	setAttr ".r" -type "double3" 180 29.999999999999577 359.99999999999534 ;
	setAttr ".rp" -type "double3" 1.5265566588595902e-016 -1.2515151057290588 2.7755575615628914e-017 ;
	setAttr ".rpt" -type "double3" -2.2229206872125995e-016 2.5030302114581175 6.3285102345618622e-017 ;
	setAttr ".sp" -type "double3" 1.5265566588595902e-016 -1.2515151057290588 2.7755575615628914e-017 ;
createNode mesh -n "triangleShape" -p "triangle";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5625 0.2499999925494194 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	setAttr ".ics" -type "componentList" 1 "f[0]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.077578147686062415 1.4500266635406032 -0.18082753675701468 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.65492833 0.18700448 -0.18082772 ;
	setAttr ".rs" 54943;
	setAttr ".lt" -type "double3" 0 2.8474312849876239e-017 0.69613319479422686 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.0771224891776461 0.18700447916865492 -2.1808277751755938 ;
	setAttr ".cbx" -type "double3" 2.3869791829949003 0.18700447916865492 1.8191723440336958 ;
createNode polyTweak -n "polyTweak1";
	setAttr ".uopa" yes;
	setAttr -s 3 ".tk[0:2]" -type "float3"  0 0.36997101 0 0 0.36997101
		 0 0 0.36997101 0;
createNode deleteComponent -n "deleteComponent1";
	setAttr ".dc" -type "componentList" 1 "f[1:3]";
createNode polyPyramid -n "polyPyramid1";
	setAttr ".w" 4;
	setAttr ".ns" 3;
	setAttr ".cuv" 3;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 2 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
connectAttr "polyExtrudeFace1.out" "triangleShape.i";
connectAttr "polyTweak1.out" "polyExtrudeFace1.ip";
connectAttr "triangleShape.wm" "polyExtrudeFace1.mp";
connectAttr "deleteComponent1.og" "polyTweak1.ip";
connectAttr "polyPyramid1.out" "deleteComponent1.ig";
connectAttr "triangleShape.iog" ":initialShadingGroup.dsm" -na;
// End of Triangle.ma
