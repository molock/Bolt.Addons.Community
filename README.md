



# Bolt.Addons.Community
A community-driven project for extending Unity Bolt with custom nodes, types, and helpers.

Development is open to the community.


#### Why Bolt.Addons.Community and not Bolt.Community.Addons?  
While the latter flows off of the tongue more naturally, this project aims to be part of a larger ecosystem of addons and so aims for the former.  If auto-adding custom types from namespaces becomes a supported  feature of Bolt, Bolt.Addons.X is preferable.

> [Direct Download (requires matching Bolt version)](https://github.com/RealityStop/Bolt.Addons.Community/releases/)


----------


 
 
 
 

## Installing
Add the dlls via the Unit Option Wizard in the assembly step and regenerate.  There is no need to add anything to the type options.  Regenerating is required before the units will be available.


## What's included
**Bold** items are units included in the dlls.  More coming soon!

### Bolt.Addons.Community.Variables

 - **Increment Variable**
 - **Decrement Variable**
 - **Plus Equals**

### Bolt.Addons.Community.Math

 - Functions
	 - **Decay**
	 - **Exponential**
	 - **Linear**
	 - **Logarithmic**
	 - **Reverse Linear**
	 - **Sigmoid**

### Bolt.Addons.Community.Logic

 - **Branch Next**
 - **Gate** (new in 1.3)
 - Conditional
	 - **Branch Equal**
	 - **Branch Greater**
	 - **Branch Less**


----------

# For Developers:

## How to build
To build the addons for Bolt version {targetversion}.  Add the following dlls from your Unity Project with {targetversion} of Bolt installed:

\Dependencies\BoltBinaries\\{targetversion}
 - Bolt.*.dll  
 - Ludiq.*.dll
(from (*Assets\Ludiq\Assemblies*) )
  
\Dependencies\UnityBinaries
 - UnityEditor.dll
 - UnityEngine.CoreModule.dll
 - UnityEngine.dll
 - UnityEngine.UI.dll

Open and build the \src\Bolt.Addons.Community.sln solution in Visual Studio 2017, selecting the Release_<targetversion> solution configuration.

The binaries will be copied to \Output\\{targetversion}


## Current contributors (aka who to blame)
 - Reality.Stop()
 - JasonJamesLASM
