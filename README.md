# vr-pano-lense-correction

Unity 3D C# script that generates a mesh to correct lens distortion in real-time on the GPU.
Fast and configurable. It is for showing video recorded with any configureation of lenses (such as double fish eye lenses) as a VR panoramic videos and still applications. Supports head tracking. Also has a Mathematica script to automatically calibrate bad lenses.

## Distance

All of this can be done with a shader.
Or I could use defered rendering.

But building lense method, after I take the photo, I can close off areas.
I can also draw the edges and it can figure it out. Not sure how that would be implemented.
Maybe draw region. Set distance.
I 'snip' out parts and put them in 3d.

## Caputure
Photo Sphere works well

## Lense distorition
Uses Mathematica. Still need to copy from my laptop and nuc.

## Sharing
This is created for the panoshare project.
