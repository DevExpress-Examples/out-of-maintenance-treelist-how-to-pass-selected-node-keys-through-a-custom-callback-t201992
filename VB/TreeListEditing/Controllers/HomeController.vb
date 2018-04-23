Imports System
Imports System.Web.Mvc
Imports TreeListEditing.Models

Namespace TreeListEditing.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View(EmployeesDataProvider.GetData())
		End Function
		Public Function TreeListPartial() As ActionResult
			Return TreeListPartialCore()
		End Function
		Public Function TreeListPartialCustom(ByVal selectedNodesIDs As String) As ActionResult
			If Not String.IsNullOrEmpty(selectedNodesIDs) Then
				ViewData("SelectedNodesIDs") = selectedNodesIDs
			End If
			Return TreeListPartialCore()
		End Function
		Public Function TreeListPartialCore() As ActionResult
			Return PartialView("TreeListPartial", EmployeesDataProvider.GetData())
		End Function
	End Class
End Namespace