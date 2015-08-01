﻿'******************************************************************************
'*
'* PDFKeeper -- PDF Document Capture, Storage, and Search
'* Copyright (C) 2009-2015 Robert F. Frasca
'*
'* This file is part of PDFKeeper.
'*
'* PDFKeeper is free software: you can redistribute it and/or modify it under
'* the terms of the GNU General Public License as published by the Free
'* Software Foundation, either version 3 of the License, or (at your option)
'* any later version.
'*
'* PDFKeeper is distributed in the hope that it will be useful, but WITHOUT
'* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
'* FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
'* more details.
'*
'* You should have received a copy of the GNU General Public License along
'* with PDFKeeper.  If not, see <http://www.gnu.org/licenses/>.
'*
'******************************************************************************

''' <summary>
''' Document Preview zoom percentage.
''' </summary>
Public NotInheritable Class Zoom
	Shared Property Percentage() As Int32 = 100
		
	''' <summary>
	''' Private constructor required for FxCop compliance (CA1053).
	''' </summary>
	Private Sub New()
	End Sub
		
	''' <summary>
	''' Increase zoom percentage by 25%.
	''' </summary>
	Public Shared Sub IncreasePercentage
		Percentage += 25
	End Sub
	
	''' <summary>
	''' Decrease zoom percentage by 25%.
	''' </summary>
	Public Shared Sub DecreasePercentage
		Percentage -= 25
		If Percentage < 100 Then
			MsgBox("oops")
		End If
	End Sub
	
	''' <summary>
	''' Reset zoom percentage to 100%.
	''' </summary>
	Public Shared Sub ResetPercentage
		Percentage = 100
	End Sub
End Class
