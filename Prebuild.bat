Echo "Copying over newest versin of Particle Code to Both Projects"
Echo "Copying SIU over to Particle Project"

XCopy ..\..\GUI\ParticleReference.cs ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.cs /R /U /Y /D

XCopy ..\..\GUI\ParticleReference.resx ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.resx /R /U /Y /D

XCopy ..\..\GUI\ParticleReference.Designer.cs ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.Designer.cs /R /U /Y /D

Echo "Copying Particle Project over to SIU"

XCopy ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.cs ..\..\GUI\ParticleReference.cs /R /U /Y /D

XCopy ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.resx ..\..\GUI\ParticleReference.resx /R /U /Y /D

XCopy ..\..\ParticleReferenceForSIU\ParticleReferenceForSIU\ParticleReference.Designer.cs ..\..\GUI\ParticleReference.Designer.cs /R /U /Y /D
Echo "Finished all copying, go build now! (This happens before the build, you do not have to re-build)"
Exit 0
