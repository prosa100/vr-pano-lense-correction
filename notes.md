Capturing the world for VR

# Capture

## Panoram

+ Google Photo Sphere
+ Hugin
+ lighweight
+ easy to caputre
+ realtime
+ can be augmented with simple modling
+ bad at expanding. Requires augmanation.

### Improvements

+ spawn props
+ mark floor
+ mark lines and cubes. where stuff hits the floor.
+ What can I dirive from something I know is a line?
+ Stero would proably be the best of both worlds.
+ Stero percsion with depth scales like a human (no derp)
+ or just 2d regions.


+ so draw a line on the ground
+ process it.
+ using a large number of lenses is better from a processing persepctive.

## 3D scaner

+ several tools.
+ faster + more relibable
+ realtime
+ kinect demo
+ realsense demo
+ slam

## Model

+ manual
+ very good runtime performance


## Photogrammetry

+ benifits from stero (Stereophotogrammetry)
+ vslam
+ can be realtime
+ messy and unreliable

[By Valve](http://steamcommunity.com/games/250820/announcements/detail/117448248511524033)
[An open source tool](http://wedidstuff.heavyimage.com/index.php/2013/07/12/open-source-photogrammetry-workflow/)

### Software
+ Autodesk Memento Beta (Web-backed, Propertary)
+ Autodesk 123D catch (Web-backed, Propertary, Free)
+ Autodesk ReCap 360 (Web-backed, Propertary, Free for edu)
+ Agisoft PhotoScan (Web-backed, Propertary, $)
+ VisualSFM (Opensource, Local)
+ NASA
+ VSLAM (several ros packages)
+ Laser range finder
+ Many, many more. https://en.wikipedia.org/wiki/Comparison_of_photogrammetry_software

### Cleanup
You need to clean up the mesh after you obtain it with photogrammetry.
+ MeshLab
+ Autodesk Mesh ????
+ http://www.cs.jhu.edu/~misha/Code/PoissonRecon/Version5.5/


# Perception

What distance should I render a photosphere?


## How far do I need 3d?

IRL at 50ft, 2ft is impossible to tell

The resolution is 20 pixels per degree.
Assume an ipd of 65mm
distance is ipd


pixelTol==angleResolution*(tan((range+spacing)/ipd)-Tan(range/ipd))

## Resolution
In theory, I need a width of 1920*4~=8k
Noyst freq? So times 2.