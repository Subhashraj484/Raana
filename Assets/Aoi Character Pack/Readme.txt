-------------------------------------------

GameAssetStudio
http://gameassetstudio.com/

-------------------------------------------

 ===========================================
 Ver 1.14 Update Information
 ===========================================

1.In Unity 4.6.2 and higher versions the Cutoff in the toon_cutoff shader wasn't working properly. This has been fixed.
2.Added more background and floor graphics to the viewer.
3.Adjusted the light in viewer.
4.You can now set the Alpha cutoff of the toon_cutoff shader. 0.9 is the recommended setting.


 ===========================================
 How to use a Model
 ===========================================

1. Select a model you wish to use from project, then right-click on it.
2. Choose Export Package…
3. Export all of the assets while Include Dependencies.
4. Specify an arbitrary directory and a package name, then create a package file.
5. Open a project in which you wish to use the model.
6. Select Asset > Import Package > Custom Package...
7. Select the Package you chose the above step 4 and import it.
8. Once the model is imported to the project, it is ready for use.

 ===========================================
 Changing the facial expression of M and L sized models
 ===========================================

1. Select Assets > Aoi Character Pack > Resources > Aoi > Materials and then f02_face_00_m or f02_face_00_l
2. In the Inspector tab where material information is displayed, select Texture. 
3. By selecting "f02_face_xxx" in the texture overview, the facial expression can be changed.
* For facial expressions, please refer to the following correspondence table.

- Neutral
f02_face_00_m.png
f02_face_00_l.png

- Angry
f02_face_010_m.png
f02_face_010_l.png

- Sad
f02_face_020_m.png
f02_face_020_l.png

- Embarrassed
f02_face_030_m.png
f02_face_030_l.png

- Wink
f02_face_040_m.png
f02_face_040_l.png

- Kiss
f02_face_050_m.png
f02_face_050_l.png

- Eyes Closed
f02_face_060_m.png
f02_face_060_l.png

- Damage
f02_face_070_m.png
f02_face_070_l.png

 ===========================================
 Unity Asset Setting
 ===========================================

In order to use all of the character asset states in the Aoi Character Pack,
please be sure to use the following settings.

Method 1
- 1. When dragging a model from the project folder to the scene, you must modify the number of bones to use per vertex for - skinning.
- 2. Bring the model into the scene and then double click on it.
- 3. In the Inspector Tab look for the "Quality" setting and change it from "Auto" to "4 Bones."
- 4. Now you are finished.
- 5. In addition, this procedure must be followed for each model you bring into the scene.

Method 2
- 1. Choose Edit > Project > Settings > Quality.
- 2. In the Inspector tab, choose Other>Blend Weights and set that to "4 Bones."
- 3. With this method there is no need to adjust model configurations each time they are brought into the scene.

Method 3
- 1. You can now set the Alpha cutoff of the toon_cutoff shader. 0.9 is the recommended setting.


-------------------------------------------


This product also supports Mecanim.
To use Mecanim, please use the settings below.

- 1. When you select a Mecanim animation in the project folder, the animation's details are displayed in the Inspector tab.
- 2. Choose the Rig tab.
- 3. "Source" is displayed as "f02_blazer_000_hAvatar".
Load "Avatar" of the costume saved in Asset > Aoi Character Pack > Resources > Aoi > Models Mecanim.
*The Mecanim animations in this product only correspond to the Aoi Character Pack.



 ===========================================
 Description of directory
 ===========================================
[Aoi Character Pack]
  [Resources]
  : The animations and models that make up the main asset are stored here. Please use them as you see fit.
    [Aoi]
      [Animations Legacy] : Legacy Animation Data
      [Animations Mecanim] : Mecanim Animation Data
      [Materials] : Material Data
      [Models Legacy] : Legacy Model Data
      [Models Mecanim] : Mecanim Model Data
      [Textures] : Texture Data
    [Shaders] : Shader Data
  [Viewer]
  : The files in the hierarchy below this are used by Viewer, so please do not move or rename any of the files

    aoi_viewer.scene : Viewer Scene File
    [GUI] : Viewer GUI Images
    [Resources] : Resources used by Viewer
      [Aoi]
        [Viewer BackGround] : Viewer Background Images
        [Viewer Materials]      : Face Materials used by Viewer
        [Viewer Settings]       : Viewer Setting File
    [Scripts] : Viewer Scripts

 ===========================================
 Unity Program Setting
 ===========================================

Asset Viewer ( WebPlayer )
Only able to use legacy animations

SceneFile:
Aoi Character Pack > Viewer > aoi_viewer.unity

Recommended Settings:
- PlayerSettings > Setting for Web Player > Resolution and Presentation
- Default Screen Width 960
- Default Screen Width 600
