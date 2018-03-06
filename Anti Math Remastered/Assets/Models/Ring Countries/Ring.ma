//Maya ASCII 2014 scene
//Name: Ring.ma
//Last modified: Fri, Jan 05, 2018 11:06:26 AM
//Codeset: 1252
requires maya "2014";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2014";
fileInfo "version" "2014 x64";
fileInfo "cutIdentifier" "201303010241-864206";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -1.5414150204545485 -1.8715787313434684 3.2409156940510724 ;
	setAttr ".r" -type "double3" -206.73835273014498 517.79999999991469 0 ;
createNode camera -s -n "perspShape" -p "persp";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 3.9560210778195724;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 3.5396102334930486;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pCylinder1";
	setAttr ".t" -type "double3" -0.0084816809934613602 0 -0.013671238049004053 ;
	setAttr ".r" -type "double3" 0 0 179.57657525479928 ;
	setAttr ".s" -type "double3" 0.74051263676929069 0.11786843983358694 0.74051263676929069 ;
createNode mesh -n "pCylinderShape1" -p "pCylinder1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode lightLinker -s -n "lightLinker1";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode displayLayerManager -n "layerManager";
createNode displayLayer -n "defaultLayer";
createNode renderLayerManager -n "renderLayerManager";
createNode renderLayer -n "defaultRenderLayer";
	setAttr ".g" yes;
createNode polyCylinder -n "polyCylinder1";
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	setAttr ".ics" -type "componentList" 1 "f[20:59]";
	setAttr ".ix" -type "matrix" 9.2650255030599782e-017 0.4172596540315906 0 0 -0.0664158070830176 1.4747271644525739e-017 0 0
		 0 0 0.4172596540315906 0 -0.0084816809934613602 0 -0.013671238049004053 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.008481618 -4.9741228e-008 -0.013671312 ;
	setAttr ".rs" 49741;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.071064086086265216 -0.3931763944547777 -0.40684773198623558 ;
	setAttr ".cbx" -type "double3" 0.054100850777441284 0.39317629497232387 0.37950510666454673 ;
createNode polyTweak -n "polyTweak1";
	setAttr ".uopa" yes;
	setAttr -s 42 ".tk[0:41]" -type "float3"  -0.054893147 0.057717476 0.017835977
		 -0.046695121 0.057718739 0.033925768 -0.033925712 0.057717174 0.046694763 -0.01783588
		 0.057719909 0.054893453 -6.8805379e-009 0.057718739 0.057718128 0.017835906 0.057719596
		 0.054893102 0.033925708 0.057716876 0.046694379 0.04669467 0.057718992 0.033925589
		 0.054893091 0.057718739 0.01783593 0.057717949 0.057718039 -1.0320713e-008 0.054893091
		 0.057718039 -0.017835924 0.046694864 0.057717174 -0.033926159 0.033925861 0.057718739
		 -0.046694763 0.017835839 0.057716317 -0.054893453 -5.1603797e-009 0.057717476 -0.057718128
		 -0.017835874 0.057716317 -0.054893102 -0.033925708 0.057721183 -0.046694499 -0.04669467
		 0.057716876 -0.033925992 -0.054893091 0.057718039 -0.017835964 -0.057717949 0.057718039
		 -1.0320713e-008 -0.054893147 -0.057718225 0.017835876 -0.046695121 -0.057718225 0.033925768
		 -0.033925712 -0.057718225 0.046694849 -0.01783588 -0.057718225 0.054893006 -6.8805379e-009
		 -0.057718225 0.057717949 0.017835906 -0.057718225 0.054893102 0.033925708 -0.057718225
		 0.04669467 0.04669467 -0.057718225 0.033925861 0.054893091 -0.057718225 0.017835801
		 0.057717949 -0.057718225 -1.0320772e-008 0.054893091 -0.057718225 -0.01783585 0.046694864
		 -0.057718225 -0.033925816 0.033925861 -0.057718225 -0.046694849 0.017835839 -0.057718225
		 -0.054893006 -5.1603797e-009 -0.057718225 -0.057717949 -0.017835874 -0.057718225
		 -0.054893102 -0.033925708 -0.057718225 -0.046694789 -0.04669467 -0.057718225 -0.033925828
		 -0.054893091 -0.057718225 -0.017835837 -0.057717949 -0.057718225 -1.0320772e-008
		 -6.8805379e-009 0.057718039 -1.0320713e-008 -6.8805379e-009 -0.057718225 -1.0320772e-008;
createNode polyTweak -n "polyTweak2";
	setAttr ".uopa" yes;
	setAttr -s 42 ".tk[40:81]" -type "float3"  -0.21406482 0.22508077 0.069553785
		 -0.18209431 0.22508042 0.13229929 -2.6831726e-008 0.22508062 -5.4280981e-008 -0.13229939
		 0.22508083 0.18209432 -0.069553874 0.22508025 0.21406466 -2.6831726e-008 0.22508042
		 0.22508092 0.069553807 0.22508028 0.21406472 0.1322993 0.22508095 0.18209437 0.1820944
		 0.22508049 0.13229929 0.21406467 0.22508042 0.069553763 0.22508095 0.22508062 -5.4280981e-008
		 0.21406467 0.22508062 -0.069553874 0.18209432 0.22508083 -0.13229924 0.13229921 0.22508042
		 -0.18209432 0.069553807 0.22508098 -0.21406466 -2.0123796e-008 0.22508077 -0.22508092
		 -0.06955383 0.22508098 -0.21406472 -0.1322993 0.22507989 -0.18209437 -0.18209445
		 0.22508095 -0.13229927 -0.21406469 0.22508062 -0.069553845 -0.22508095 0.22508062
		 -5.4280981e-008 -0.21406482 -0.22508098 0.069553792 -0.18209431 -0.22508098 0.13229929
		 -2.6831726e-008 -0.22508098 -5.4280981e-008 -0.13229939 -0.22508098 0.1820944 -0.069553874
		 -0.22508098 0.21406472 -2.6831726e-008 -0.22508098 0.22508098 0.069553807 -0.22508098
		 0.21406472 0.1322993 -0.22508098 0.1820944 0.1820944 -0.22508098 0.13229923 0.21406467
		 -0.22508098 0.069553785 0.22508095 -0.22508098 -5.4280981e-008 0.21406467 -0.22508098
		 -0.069553882 0.18209432 -0.22508098 -0.13229933 0.13229921 -0.22508098 -0.18209445
		 0.069553807 -0.22508098 -0.21406472 -2.0123796e-008 -0.22508098 -0.22508098 -0.06955383
		 -0.22508098 -0.21406472 -0.1322993 -0.22508098 -0.18209445 -0.18209445 -0.22508098
		 -0.1322993 -0.21406469 -0.22508098 -0.069553882 -0.22508095 -0.22508098 -5.4280981e-008;
createNode deleteComponent -n "deleteComponent1";
	setAttr ".dc" -type "componentList" 1 "f[20:59]";
createNode polyAppend -n "polyAppend1";
	setAttr -s 2 ".d[0:1]"  -2147483510 -2147483549;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend2";
	setAttr -s 3 ".d[0:2]"  -2147483550 -2147483512 -2147483507;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend3";
	setAttr -s 3 ".d[0:2]"  -2147483552 -2147483514 -2147483506;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend4";
	setAttr -s 3 ".d[0:2]"  -2147483586 -2147483508 -2147483509;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend5";
	setAttr -s 5 ".d[0:4]"  -2147483584 -2147483504 -2147483546 -2147483544 -2147483582;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend6";
	setAttr -s 3 ".d[0:2]"  -2147483554 -2147483516 -2147483505;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend7";
	setAttr -s 3 ".d[0:2]"  -2147483556 -2147483518 -2147483502;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend8";
	setAttr -s 6 ".d[0:5]"  -2147483520 -2147483501 -2147483558 -2147483560 -2147483562 -2147483522;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend9";
	setAttr -s 4 ".d[0:3]"  -2147483524 -2147483500 -2147483564 -2147483526;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend10";
	setAttr -s 3 ".d[0:2]"  -2147483499 -2147483566 -2147483528;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend11";
	setAttr -s 2 ".d[0:1]"  -2147483498 -2147483568;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend12";
	setAttr -s 4 ".d[0:3]"  -2147483530 -2147483497 -2147483570 -2147483532;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend13";
	setAttr -s 2 ".d[0:1]"  -2147483572 -2147483496;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend14";
	setAttr -s 5 ".d[0:4]"  -2147483534 -2147483495 -2147483574 -2147483576 -2147483536;
	setAttr ".tx" 1;
createNode polyAppend -n "polyAppend15";
	setAttr -s 7 ".d[0:6]"  -2147483538 -2147483494 -2147483578 -2147483580 -2147483503 -2147483542 
		-2147483540;
	setAttr ".tx" 1;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -s 2 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 18 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surfaces" "Particles" "Fluids" "Image Planes" "UI:" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 18 0 1 1 1 1 1
		 1 0 0 0 0 0 0 0 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polyAppend15.out" "pCylinderShape1.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyTweak1.out" "polyExtrudeFace1.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace1.mp";
connectAttr "polyCylinder1.out" "polyTweak1.ip";
connectAttr "polyExtrudeFace1.out" "polyTweak2.ip";
connectAttr "polyTweak2.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "polyAppend1.ip";
connectAttr "polyAppend1.out" "polyAppend2.ip";
connectAttr "polyAppend2.out" "polyAppend3.ip";
connectAttr "polyAppend3.out" "polyAppend4.ip";
connectAttr "polyAppend4.out" "polyAppend5.ip";
connectAttr "polyAppend5.out" "polyAppend6.ip";
connectAttr "polyAppend6.out" "polyAppend7.ip";
connectAttr "polyAppend7.out" "polyAppend8.ip";
connectAttr "polyAppend8.out" "polyAppend9.ip";
connectAttr "polyAppend9.out" "polyAppend10.ip";
connectAttr "polyAppend10.out" "polyAppend11.ip";
connectAttr "polyAppend11.out" "polyAppend12.ip";
connectAttr "polyAppend12.out" "polyAppend13.ip";
connectAttr "polyAppend13.out" "polyAppend14.ip";
connectAttr "polyAppend14.out" "polyAppend15.ip";
connectAttr "pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
// End of Ring.ma
