# Licensed Materials - Property of IBM
# 5725-I43 (C) Copyright IBM Corp. 2011, 2013. All Rights Reserved.
# US Government Users Restricted Rights - Use, duplication or
# disclosure restricted by GSA ADP Schedule Contract with IBM Corp.

param($installPath, $toolsPath, $package, $project)
# The content folder isn't valid (yet) for NuGet 3. So add mfpclient.resw manually.
$strings = $installPath + "\content\strings"
$mfpclientresw = $installPath + "\content\strings\mfpclient.resw"
$stringFolder = $project.ProjectItems.AddFolder("strings")
$stringFolder.ProjectItems.AddFromFileCopy($mfpclientresw)
